using App.Scripts.Weapon;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemySprayAttack: IAttackMode, ITickable
    {
        public bool IsAttacking { get; private set; }
        
        private readonly IEnemyChaseManager _enemyChaseManager;
        private readonly IEnemySpray _enemySpray;

        public EnemySprayAttack(IEnemyChaseManager enemyChaseManager, IEnemySpray enemySpray)
        {
            _enemyChaseManager = enemyChaseManager;
            _enemySpray = enemySpray;
        }

        public void Tick()
        {
            if (IsAttacking)
            {
                Attack();
            }
        }

        public void SetReady(bool isReady)
        {
            IsAttacking = isReady;
            _enemySpray.gameObject.SetActive(isReady);
        }

        public void Attack()
        {
            _enemySpray.SprayTo(_enemyChaseManager.Target.transform);
        }
    }
}