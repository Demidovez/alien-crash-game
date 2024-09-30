using App.Scripts.Tools.WayPoints;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyNavigation: IInitializable, ITickable
    {
        public bool IsReachedDestination { get; private set; }
        public bool IsMoving { get; private set; }
        public bool IsRunning { get; private set; }
        public Transform CurrentTransform => _navMeshAgent.transform;

        private readonly NavMeshAgent _navMeshAgent;
        private readonly float _chaseSpeed;
        private readonly float _speed;

        private WayPoint _currentWayPoint;
        private int _direction;
        private Vector3 _defaultDestination;
        private Transform _forceDestinationTarget;

        public EnemyNavigation(
            NavMeshAgent navMeshAgent, 
            float minMoveSpeed, 
            float maxMoveSpeed, 
            float chaseSpeed
        )
        {
            _navMeshAgent = navMeshAgent;
            
            _chaseSpeed = chaseSpeed;
            _speed = Random.Range(minMoveSpeed, maxMoveSpeed);
            _direction = Random.Range(0, 2);
            
            _navMeshAgent.speed = _speed;
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
            CorrectWayNavigation();
            CorrectTargetNavigation();
            CorrectRotation();
            CheckReachedDestination();
            
            IsMoving = _navMeshAgent.velocity.magnitude >= 1f;
            IsRunning = IsMoving && Mathf.Approximately(_navMeshAgent.speed, _chaseSpeed);
        }

        private void CheckReachedDestination()
        {
            float reachedCoefficient = 1;
            
            if (_forceDestinationTarget && IsReachedDestination)
            {
                reachedCoefficient = 1.3f;
            }
            
            IsReachedDestination = _navMeshAgent.remainingDistance <= reachedCoefficient * _navMeshAgent.stoppingDistance;
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
        
        public void SetDirection(int direction)
        {
            _direction = direction;
        }
        
        public void SetDestination(WayPoint wayPoint)
        {
            _navMeshAgent.SetDestination(wayPoint.GetPosition());
            IsReachedDestination = false;
        }
        
        public void SetForceDestinationTarget(Transform target)
        {
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
    }
}