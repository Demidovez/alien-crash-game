using App.Scripts.Common;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public class EnemyHitAttack: IAttackMode
    {
        public bool IsAttacking { get; set; }
        
        private readonly IEnemyChaseManager _enemyChaseManager;
        private const float DamageValue = 10f;

        public EnemyHitAttack(IEnemyChaseManager enemyChaseManager)
        {
            _enemyChaseManager = enemyChaseManager;
        }

        public void SetReady(bool isReady)
        {
            IsAttacking = isReady;
        }

        public void Attack()
        {
            if (!_enemyChaseManager.IsFocusedOnTarget())
            {
                return;
            }

            GameObject target = _enemyChaseManager.Target.gameObject;
            
            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(DamageValue);
            }
        }
    }
}