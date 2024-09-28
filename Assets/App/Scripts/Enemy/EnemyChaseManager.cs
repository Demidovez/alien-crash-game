using System;
using App.Scripts.Components;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyChaseManager : ITickable, IDisposable
    {
        public bool IsChasing { get; private set; }
        
        private readonly EnemyNavigation _enemyNavigation;
        private readonly FieldOfView _fieldOfView;
        
        private const float ChaseDelay = 3f;
        private Transform _target;
        private float _chaseTime;
        private bool _shouldReset;

        public EnemyChaseManager(
            FieldOfView fieldOfView,
            EnemyNavigation enemyNavigation
        )
        {
            _enemyNavigation = enemyNavigation;
            _fieldOfView = fieldOfView;
            
            _fieldOfView.OnAddedVisibleTarget += TryAddChaseTarget;
            _fieldOfView.OnRemovedVisibleTarget += TryRemoveChaseTarget;
        }
        
        public void Tick()
        {
            if (_shouldReset)
            {
                _chaseTime += Time.deltaTime;
            }

            ResetChase();
        }
        
        public void Dispose()
        {
            _fieldOfView.OnAddedVisibleTarget -= TryAddChaseTarget;
            _fieldOfView.OnRemovedVisibleTarget -= TryRemoveChaseTarget;
        }

        private void ResetChase()
        {
            if (_shouldReset && _chaseTime >= ChaseDelay)
            {
                _shouldReset = false;

                IsChasing = false;
                _target = null;
                _enemyNavigation.SetForceDestinationTarget(null);
            }
        }

        private void TryAddChaseTarget(Transform target)
        {
            if (_target)
            {
                _shouldReset = false;
                return;
            }

            IsChasing = true;
            _target = target;
            _enemyNavigation.SetForceDestinationTarget(target);
        }
        
        private void TryRemoveChaseTarget(Transform target)
        {
            if (_target == target)
            {
                _shouldReset = true;
                _chaseTime = 0f;
            }
        }
    }
}