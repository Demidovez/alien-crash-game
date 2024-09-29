using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyAnimation : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyNavigation _enemyNavigation;
        private readonly EnemyAttack _enemyAttack;
        
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        
        public EnemyAnimation(
            Animator animator, 
            EnemyNavigation enemyNavigation,
            EnemyAttack enemyAttack
        )
        {
            _animator = animator;
            _enemyNavigation = enemyNavigation;
            _enemyAttack = enemyAttack;
        }
        
        public void Tick()
        {
            bool isWalkingAnim = _enemyNavigation.IsMoving && !_enemyNavigation.IsRunning && !_enemyAttack.IsAttacking;
            bool isRunningAnim = _enemyNavigation.IsRunning && !_enemyAttack.IsAttacking;

            _animator.SetBool(IsWalking, isWalkingAnim);
            _animator.SetBool(IsRunning, isRunningAnim);
            _animator.SetBool(IsAttacking, _enemyAttack.IsAttacking);
        }
    }
}