using System;
using App.Scripts.Components;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyChaseManager : ITickable, IDisposable
    {
        private readonly EnemyMovement _enemyMovement;
        private readonly FieldOfView _fieldOfView;
        private const float ChaseDelay = 3f;
        private Transform _target;

        private float _chaseTime;
        private bool _shouldReset;

        public EnemyChaseManager(
            FieldOfView fieldOfView,
            EnemyMovement enemyMovement
        )
        {
            _enemyMovement = enemyMovement;
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
                
                _target = null;
                
                _enemyMovement.SetForceMoveTarget(null);
            }
        }

        private void TryAddChaseTarget(Transform target)
        {
            if (_target)
            {
                _shouldReset = false;
                return;
            }

            _target = target;
            _enemyMovement.SetForceMoveTarget(target);
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