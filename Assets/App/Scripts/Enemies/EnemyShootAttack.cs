using App.Scripts.Bullets;
using App.Scripts.Weapon;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public class EnemyShootAttack: IAttackMode
    {
        private readonly EnemyChaseManager _enemyChaseManager;
        private readonly EnemyPistol _enemyPistol;

        public EnemyShootAttack(EnemyChaseManager enemyChaseManager, EnemyPistol enemyPistol)
        {
            _enemyChaseManager = enemyChaseManager;
            _enemyPistol = enemyPistol;
        }

        public void SetReady(bool isReady)
        {
            _enemyPistol.gameObject.SetActive(isReady);
        }

        public void Attack()
        {
            _enemyPistol.Shoot();

            Transform target = _enemyChaseManager.Target.transform;
            Vector3 targetPosition = target.position;
            
            if (target.TryGetComponent(out Collider collider))
            {
                float targetHeight = collider.bounds.size.y;
                targetPosition.y += targetHeight * 0.7f;
            }
            
            Bullet bullet = _enemyPistol.GetBullet();
            bullet.MoveFromTo(_enemyPistol.ShootPoint.position, targetPosition);
        }
    }
}