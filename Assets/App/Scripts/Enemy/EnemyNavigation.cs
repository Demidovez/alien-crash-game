using App.Scripts.Entity;
using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemy
{
    public class EnemyNavigation: MonoBehaviour, IEntityNavigation
    {
        private WayPoint _currentWayPoint;
        private EnemyMovement _enemyMovement;
        private int _direction;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        private void Start()
        {
            if (_currentWayPoint)
            {
                SetDestination(_currentWayPoint);
            }
        }

        private void Update()
        {
            if (_currentWayPoint && _enemyMovement.IsReachedDestination)
            {
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
            _enemyMovement.SetDestination(wayPoint.GetPosition());
        }
    }
}