using App.Scripts.Common;
using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy, IDamageableWithAttacker
    {
        private IEnemyNavigation _enemyNavigation;
        private IEnemyHealth _enemyHealth;

        [Inject]
        public void Construct(
            IEnemyNavigation enemyNavigation,
            IEnemyHealth enemyHealth
        )
        {
            _enemyNavigation = enemyNavigation;
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

