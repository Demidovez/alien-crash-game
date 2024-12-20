﻿using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyAttack: IEnemyAttack, ITickable
    {
        private readonly IEnemyNavigation _enemyNavigation;
        private readonly IEnemyChaseManager _enemyChaseManager;
        private readonly IAttackMode _attackMode;
        
        public bool IsAttacking { get; private set; }

        public EnemyAttack(
            IEnemyNavigation enemyNavigation, 
            IEnemyChaseManager enemyChaseManager, 
            IAttackMode attackMode
        )
        {
            _enemyNavigation = enemyNavigation;
            _enemyChaseManager = enemyChaseManager;
            _attackMode = attackMode;
        }

        public void Tick()
        {
            IsAttacking = !_enemyNavigation.IsWaiting && _enemyNavigation.IsReachedDestination && _enemyChaseManager.IsChasing;

            if (IsAttacking && !_attackMode.IsAttacking)
            {
                _attackMode.SetReady(true);
            } else if (!IsAttacking && _attackMode.IsAttacking)
            {
                _attackMode.SetReady(false);
            }
        }

        public void TryAttack()
        {
            if (!IsAttacking)
            {
                return;
            }
            
            _attackMode.Attack();
        }
    }
}