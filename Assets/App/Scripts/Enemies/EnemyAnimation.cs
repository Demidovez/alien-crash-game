using System;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyAnimation : IEnemyAnimation, ITickable, IDisposable
    {
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int IsConcussion = Animator.StringToHash("IsConcussion");
        private static readonly int ConcussionTrigger = Animator.StringToHash("ConcussionTrigger");
        private static readonly int UnderAttackTrigger = Animator.StringToHash("UnderAttackTrigger");
        
        private readonly Animator _animator;
        private readonly IEnemyNavigation _enemyNavigation;
        private readonly IEnemyAttack _enemyAttack;
        private readonly IEnemyHealth _enemyHealth;

        public EnemyAnimation(
            Animator animator, 
            IEnemyNavigation enemyNavigation,
            IEnemyAttack enemyAttack,
            IEnemyHealth enemyHealth
        )
        {
            _animator = animator;
            _enemyNavigation = enemyNavigation;
            _enemyAttack = enemyAttack;
            _enemyHealth = enemyHealth;

            _enemyHealth.OnTookDamageEvent += OnTookDamage;
            _enemyHealth.OnConcussionEvent += OnConcussion;
        }

        public void Tick()
        {
            bool isWalkingAnim = _enemyNavigation.IsMoving && !_enemyNavigation.IsRunning && !_enemyAttack.IsAttacking;
            bool isRunningAnim = _enemyNavigation.IsRunning && !_enemyAttack.IsAttacking;

            _animator.SetBool(IsWalking, isWalkingAnim);
            _animator.SetBool(IsRunning, isRunningAnim);
            _animator.SetBool(IsConcussion, _enemyHealth.IsConcussion);
            _animator.SetBool(IsAttacking, _enemyAttack.IsAttacking);
        }

        private void OnTookDamage(Transform _)
        {
            _animator.SetTrigger(UnderAttackTrigger);
        }

        private void OnConcussion()
        {
            _animator.SetTrigger(ConcussionTrigger);
        }

        public void Dispose()
        {
            _enemyHealth.OnTookDamageEvent -= OnTookDamage;
            _enemyHealth.OnConcussionEvent -= OnConcussion;
        }
    }
}