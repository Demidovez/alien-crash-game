using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyMovement : ITickable
    {
        private readonly float _chaseSpeed;
        private readonly float _speed;
        private readonly NavMeshAgent _navMeshAgent;

        private Transform _forceMoveTarget;
        private Vector3 _defaultDestination;

        public bool IsReachedDestination { get; private set; }
        public bool IsMoving { get; private set; }
        public bool IsRunning { get; private set; }
        
        // TODO: перенести в другое место
        public bool IsAttacking { get; private set; }

        public EnemyMovement(NavMeshAgent navMeshAgent, float minMoveSpeed, float maxMoveSpeed, float chaseSpeed)
        {
            _navMeshAgent = navMeshAgent;
            _chaseSpeed = chaseSpeed;
            _speed = Random.Range(minMoveSpeed, maxMoveSpeed);
            
            _navMeshAgent.speed = _speed;
        }

        public void Tick()
        {
            if (_forceMoveTarget)
            {
                _navMeshAgent.SetDestination(_forceMoveTarget.position);
            }
            
            IsReachedDestination = _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;

            if (IsReachedDestination && _forceMoveTarget)
            {
                IsAttacking = true; // TODO: временно
                IsRunning = false;
                IsMoving = false;
            }
            else
            {
                IsMoving = _navMeshAgent.velocity.magnitude >= 0.1f;
            }
        }

        public void SetDestination(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
            IsReachedDestination = false;
        }
        
        public void SetForceMoveTarget(Transform target)
        {
            _forceMoveTarget = target;
            IsRunning = target;
            
            if (target)
            {
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