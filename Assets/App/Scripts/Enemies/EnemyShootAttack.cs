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

            Vector3 targetPosition = _enemyChaseManager.Target.transform.position;
            
            Bullet bullet = _enemyPistol.GetBullet();
            bullet.MoveFromTo(_enemyPistol.ShootPoint.position, targetPosition);
        }
    }
}