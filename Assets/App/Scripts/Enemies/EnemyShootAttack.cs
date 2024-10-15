using App.Scripts.Common;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public class EnemyShootAttack: IAttackMode
    {
        private readonly EnemyChaseManager _enemyChaseManager;
        private readonly Transform _shootStartPoint;
        private const float DamageValue = 10f;

        public EnemyShootAttack(EnemyChaseManager enemyChaseManager, Transform shootStartPoint)
        {
            _enemyChaseManager = enemyChaseManager;
            _shootStartPoint = shootStartPoint;
        }

        public void Attack()
        {
            // if (!_enemyChaseManager.IsFocusedOnTarget())
            // {
            //     return;
            // }

            GameObject target = _enemyChaseManager.Target.gameObject;
            
            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(DamageValue);
            }
        }
    }
}