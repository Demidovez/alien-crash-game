using App.Scripts.Common;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public class EnemySprayAttack: IAttackMode
    {
        private readonly EnemyChaseManager _enemyChaseManager;
        private const float DamageValue = 10f;

        public EnemySprayAttack(EnemyChaseManager enemyChaseManager)
        {
            _enemyChaseManager = enemyChaseManager;
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