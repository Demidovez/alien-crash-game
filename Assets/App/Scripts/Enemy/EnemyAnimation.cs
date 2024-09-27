using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyAnimation : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyMovement _enemyMovement;
        
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        
        public EnemyAnimation(Animator animator, EnemyMovement enemyMovement)
        {
            _animator = animator;
            _enemyMovement = enemyMovement;
        }
        
        public void Tick()
        {
            _animator.SetBool(IsWalking, _enemyMovement.IsMoving);
            _animator.SetBool(IsRunning, _enemyMovement.IsRunning);
            _animator.SetBool(IsAttacking, _enemyMovement.IsAttacking);
        }
    }
}