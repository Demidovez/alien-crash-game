using App.Scripts.Common;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyShooting: ITickable
    {
        private readonly EnemyNavigation _enemyNavigation;
        private readonly EnemyChaseManager _enemyChaseManager;
        private readonly Transform _weaponShootPoint;
        private const float DamageValue = 10f;
        
        public bool IsAttacking { get; private set; }

        public EnemyShooting(EnemyNavigation enemyNavigation, EnemyChaseManager enemyChaseManager, Transform weaponShootPoint)
        {
            _enemyNavigation = enemyNavigation;
            _enemyChaseManager = enemyChaseManager;
            _weaponShootPoint = weaponShootPoint;
        }

        public void Tick()
        {
            IsAttacking = !_enemyNavigation.IsWaiting && _enemyNavigation.IsReachedDestination && _enemyChaseManager.IsChasing;
        }

        public void TryShoot()
        {
            if (!IsAttacking || !_enemyChaseManager.IsFocusedOnTarget())
            {
                return;
            }
            
            // Bullet bullet = _bulletsPool.GetBullet();
            // bullet.MoveFromTo(_player.transform, _weaponShootPoint.position, _enemyChaseManager.Target);
            //     
            // OnShootEvent?.Invoke();
        }
    }
}