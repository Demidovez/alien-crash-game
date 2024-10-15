using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyAttack: ITickable
    {
        private readonly EnemyNavigation _enemyNavigation;
        private readonly EnemyChaseManager _enemyChaseManager;
        private readonly IAttackMode _attackMode;
        
        public bool IsAttacking { get; private set; }

        public EnemyAttack(
            EnemyNavigation enemyNavigation, 
            EnemyChaseManager enemyChaseManager, 
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