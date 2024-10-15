using App.Scripts.Common;
using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy, IDamageableWithAttacker
    {
        private EnemyNavigation _enemyNavigation;
        private EnemyAttack _enemyAttack;
        private EnemyHealth _enemyHealth;

        [Inject]
        public void Construct(
            EnemyNavigation enemyNavigation,
            EnemyHealth enemyHealth,
            EnemyAttack enemyAttack
        )
        {
            _enemyNavigation = enemyNavigation;
            _enemyAttack = enemyAttack;
            _enemyHealth = enemyHealth;
        }
        
        public void Init(WayPoint initWayPoint)
        {
            _enemyNavigation.SetCurrentWayPoint(initWayPoint);
        }

        public void Damage(float damage, Transform attacker)
        {
            _enemyHealth.TryTakeDamage(damage, attacker);
        }
    } 
}

