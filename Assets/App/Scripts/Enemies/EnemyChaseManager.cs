﻿using System;
using App.Scripts.Components;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyChaseManager : ITickable, IDisposable
    {
        public bool IsChasing { get; private set; }
        public Transform Target { get; private set; }
        
        private readonly EnemyNavigation _enemyNavigation;
        private readonly FieldOfView _fieldOfView;
        
        private const float ChaseDelay = 3f;
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
                Target = null;
                _enemyNavigation.SetForceDestinationTarget(null);
            }
        }

        private void TryAddChaseTarget(Transform target)
        {
            if (Target)
            {
                _shouldReset = false;
                return;
            }

            IsChasing = true;
            Target = target;
            _enemyNavigation.SetForceDestinationTarget(target);
        }
        
        private void TryRemoveChaseTarget(Transform target)
        {
            if (Target == target)
            {
                _shouldReset = true;
                _chaseTime = 0f;
            }
        }
    }
}