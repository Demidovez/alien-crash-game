﻿using App.Scripts.Players;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyAttack: ITickable
    {
        private readonly EnemyNavigation _enemyNavigation;
        private readonly EnemyChaseManager _enemyChaseManager;
        public bool IsAttacking { get; private set; }

        public EnemyAttack(EnemyNavigation enemyNavigation, EnemyChaseManager enemyChaseManager)
        {
            _enemyNavigation = enemyNavigation;
            _enemyChaseManager = enemyChaseManager;
        }

        public void Tick()
        {
            IsAttacking = _enemyNavigation.IsReachedDestination && _enemyChaseManager.IsChasing;
        }

        public void TryAttack()
        {
            if (!IsAttacking || !_enemyChaseManager.IsFocusedOnTarget())
            {
                return;
            }

            GameObject target = _enemyChaseManager.Target.gameObject;
            
            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(10);
            }
        }
    }
}