using App.Scripts.Weapon;

namespace App.Scripts.Enemies
{
    public class EnemyShootAttack: IAttackMode
    {
        public bool IsAttacking { get; set; }
        
        private readonly EnemyChaseManager _enemyChaseManager;
        private readonly EnemyPistol _enemyPistol;

        public EnemyShootAttack(EnemyChaseManager enemyChaseManager, EnemyPistol enemyPistol)
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