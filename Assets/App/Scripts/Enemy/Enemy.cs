using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private EnemyNavigation _enemyNavigation;

        [Inject]
        public void Construct(EnemyNavigation enemyNavigation)
        {
            _enemyNavigation = enemyNavigation;
        }
        
        public void Init(WayPoint initWayPoint)
        {
            _enemyNavigation.SetCurrentWayPoint(initWayPoint);
        }
    } 
}

