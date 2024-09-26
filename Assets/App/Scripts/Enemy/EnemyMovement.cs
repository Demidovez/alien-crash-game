using UnityEngine;
using UnityEngine.AI;

namespace App.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _minMoveSpeed = 0.75f;
        [SerializeField] private float _maxMoveSpeed = 1.5f;
        [SerializeField] private float _chaseSpeed = 10f;
        
        private Transform _forceMoveTarget;
        private Vector3 _defaultDestination;
        private NavMeshAgent _navMeshAgent;
        private float _speed;
        
        public bool IsReachedDestination { get; private set; }

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _speed = Random.Range(_minMoveSpeed, _maxMoveSpeed);

            _navMeshAgent.speed = _speed;
        }

        private void Update()
        {
            if (_forceMoveTarget)
            {
                _navMeshAgent.SetDestination(_forceMoveTarget.position);
                IsReachedDestination = false;
            }
            else
            {
                IsReachedDestination = _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;
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