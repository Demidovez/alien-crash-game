using App.Scripts.Weapon;

namespace App.Scripts.Enemies
{
    public class EnemyShootAttack: IAttackMode
    {
        public bool IsAttacking { get; private set; }
        
        private readonly IEnemyChaseManager _enemyChaseManager;
        private readonly IEnemyPistol _enemyPistol;

        public EnemyShootAttack(IEnemyChaseManager enemyChaseManager, IEnemyPistol enemyPistol)
        {
            _enemyChaseManager = enemyChaseManager;
            _enemyPistol = enemyPistol;
        }

        public void SetReady(bool isReady)
        {
            IsAttacking = isReady;
            _enemyPistol.gameObject.SetActive(isReady);
        }

        public void Attack()
        {
            _enemyPistol.ShootTo(_enemyChaseManager.Target.transform);
        }
    }
}