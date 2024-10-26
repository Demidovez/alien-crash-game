using System;
using App.Scripts.Components;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyChaseManager : IEnemyChaseManager, ITickable, IDisposable
    {
        public bool IsChasing { get; private set; }
        public Transform Target { get; private set; }
        
        private readonly IEnemyNavigation _enemyNavigation;
        private readonly IFieldOfView _fieldOfView;

        private const float FocusDistance = 2f;
        private const float ChaseDelay = 3f;
        private float _chaseTime;
        private bool _shouldReset;

        public EnemyChaseManager(
            IFieldOfView fieldOfView,
            IEnemyNavigation enemyNavigation
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

        public bool IsFocusedOnTarget()
        {
            if (!Target)
            {
                return false;
            }

            Vector3 directionToTarget = _enemyNavigation.CurrentTransform.forward.normalized;
            Vector3 startRay = _enemyNavigation.CurrentTransform.position + Vector3.up;
            
            if (Physics.Raycast(startRay, directionToTarget, out RaycastHit hitInfo, FocusDistance))
            {
                if (hitInfo.collider.gameObject == Target.gameObject)
                {
                    return true;
                }
            }
            
            return false;
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