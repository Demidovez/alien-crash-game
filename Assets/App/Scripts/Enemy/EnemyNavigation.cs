using App.Scripts.Entity;
using App.Scripts.Tools.WayPoints;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyNavigation: IInitializable, ITickable, IEntityNavigation
    {
        private readonly EnemyMovement _enemyMovement;
        
        private WayPoint _currentWayPoint;
        private int _direction;
        
        public EnemyNavigation(EnemyMovement enemyMovement)
        {
            _enemyMovement = enemyMovement;
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