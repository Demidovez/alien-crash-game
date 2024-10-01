using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy, IAttacker
    {
        private EnemyNavigation _enemyNavigation;
        private EnemyAttack _enemyAttack;

        [Inject]
        public void Construct(
            EnemyNavigation enemyNavigation,
            EnemyAttack enemyAttack
        )
        {
            _enemyNavigation = enemyNavigation;
            _enemyAttack = enemyAttack;
        }
        
        public void Init(WayPoint initWayPoint)
        {
            _enemyNavigation.SetCurrentWayPoint(initWayPoint);
        }

        public void Attack()
        {
            _enemyAttack.TryAttack();
        }
    } 
}

