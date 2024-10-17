using System;
using System.Collections;
using App.Scripts.Infrastructure;
using App.Scripts.Tools.WayPoints;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace App.Scripts.Enemies
{
    public class EnemyNavigation: IInitializable, ITickable, IDisposable
    {
        public bool IsReachedDestination { get; private set; }
        public bool IsMoving { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsWaiting { get; private set; }
        public Transform CurrentTransform => _navMeshAgent.transform;

        private const float DelayToSetTarget = 1.5f;
        
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyHealth _enemyHealth;
        private readonly AsyncProcessor _asyncProcessor;
        private readonly float _chaseSpeed;
        private readonly float _speed;
        private readonly float _initialStopDistance;
        private readonly float _deltaStopDistance;

        private WayPoint _currentWayPoint;
        private int _direction;
        private Vector3 _defaultDestination;
        private Transform _forceDestinationTarget;

        public EnemyNavigation(
            NavMeshAgent navMeshAgent, 
            EnemyHealth enemyHealth,
            AsyncProcessor asyncProcessor,
            float minMoveSpeed, 
            float maxMoveSpeed, 
            float chaseSpeed,
            float deltaStopDistance
        )
        {
            _navMeshAgent = navMeshAgent;
            _enemyHealth = enemyHealth;
            _asyncProcessor = asyncProcessor;

            _chaseSpeed = chaseSpeed;
            _speed = Random.Range(minMoveSpeed, maxMoveSpeed);
            _direction = Random.Range(0, 2);
            _initialStopDistance = _navMeshAgent.stoppingDistance;
            _deltaStopDistance = deltaStopDistance;
            
            _navMeshAgent.speed = _speed;
            _enemyHealth.OnTookDamageEvent += OnTookDamage;
            _enemyHealth.OnConcussionEvent += OnConcussion;
            _enemyHealth.OnOutFromConcussionEvent += OnOutFromConcussion;
        }

        public void Initialize()
        {
            if (_currentWayPoint)
            {
                SetDestination(_currentWayPoint);
            }
        }

        public void Tick()
        {
            if (!_enemyHealth.IsConcussion)
            {
                CorrectWayNavigation();
                CorrectTargetNavigation();
                CorrectRotation();
                CheckReachedDestination();  
            }
            
            IsMoving = _navMeshAgent.velocity.magnitude >= 1f;
            IsRunning = IsMoving && Mathf.Approximately(_navMeshAgent.speed, _chaseSpeed);
        }

        private void CheckReachedDestination()
        {
            float stopDistanceCoefficient = 1;
            
            if (_forceDestinationTarget && IsReachedDestination)
            {
                stopDistanceCoefficient = _deltaStopDistance;
            }

            _navMeshAgent.stoppingDistance = stopDistanceCoefficient * _initialStopDistance;

            IsWaiting = _navMeshAgent.remainingDistance == 0;
            IsReachedDestination = _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;
        }

        private void CorrectRotation()
        {
            if (_forceDestinationTarget && IsReachedDestination)
            {
                Vector3 direction = _forceDestinationTarget.position - _navMeshAgent.transform.position;
                Quaternion target = Quaternion.LookRotation(direction);
                float speed = 100 * Time.deltaTime;
                Quaternion smoothTarget = Quaternion.RotateTowards(_navMeshAgent.transform.rotation, target, speed);

                _navMeshAgent.transform.rotation = smoothTarget;
            }
        }

        private void CorrectTargetNavigation()
        {
            if (_forceDestinationTarget)
            {
                _navMeshAgent.SetDestination(_forceDestinationTarget.position);
            }
        }

        private void CorrectWayNavigation()
        {
            if (_forceDestinationTarget || !_currentWayPoint || !IsReachedDestination)
            {
                return;
            }
            
            if (_direction == 0)
            {
                if (_currentWayPoint.Next)
                {
                    _currentWayPoint = _currentWayPoint.Next;
                }
                else
                {
                    _direction = 1;
                    _currentWayPoint = _currentWayPoint.Previous;
                }
            }
            else
            {
                if (_currentWayPoint.Previous)
                {
                    _currentWayPoint = _currentWayPoint.Previous;
                }
                else
                {
                    _direction = 0;
                    _currentWayPoint = _currentWayPoint.Next;
                }
            }
                
            SetDestination(_currentWayPoint);
        }

        public void SetCurrentWayPoint(WayPoint wayPoint)
        {
            _currentWayPoint = wayPoint;
        }

        private void SetDestination(WayPoint wayPoint)
        {
            _navMeshAgent.SetDestination(wayPoint.GetPosition());
            IsReachedDestination = false;
        }

        public void SetForceDestinationTarget(Transform target)
        {
            if (_enemyHealth.IsConcussion)
            {
                return;
            }
            
            _forceDestinationTarget = target;
            
            if (target)
            {
                IsReachedDestination = false;
                _defaultDestination = _navMeshAgent.destination;
                _navMeshAgent.speed = _chaseSpeed;
            }
            else
            {
                _navMeshAgent.SetDestination(_defaultDestination);
                _navMeshAgent.speed = _speed;
            }
        }

        private void OnTookDamage(Transform attacker)
        {
            _navMeshAgent.speed = 0f;
            _asyncProcessor.StartCoroutine(SetForceDestinationTargetWithDelay(attacker));
        }

        private void OnConcussion()
        {
            _navMeshAgent.speed = 0f;
            _navMeshAgent.SetDestination(_defaultDestination);

            IsReachedDestination = true;
            _forceDestinationTarget = null;
        }

        private void OnOutFromConcussion()
        {
            _navMeshAgent.speed = _speed;
        }

        private IEnumerator SetForceDestinationTargetWithDelay(Transform attacker)
        {
            yield return new WaitForSeconds(DelayToSetTarget);
            SetForceDestinationTarget(attacker);
        }

        public void Dispose()
        {
            _enemyHealth.OnTookDamageEvent -= OnTookDamage;
            _enemyHealth.OnConcussionEvent -= OnConcussion;
            _enemyHealth.OnOutFromConcussionEvent -= OnOutFromConcussion;
        }
    }
}