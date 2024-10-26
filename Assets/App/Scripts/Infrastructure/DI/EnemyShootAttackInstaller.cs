using App.Scripts.Enemies;
using App.Scripts.Weapon;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemyShootAttackInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemyShoot();
            BindEnemyPistol();
        }

        private void BindEnemyPistol()
        {
            Container
                .Bind<IEnemyPistol>()
                .To<EnemyPistol>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyShoot()
        {
            Container
                .Bind<IAttackMode>()
                .To<EnemyShootAttack>()
                .AsSingle();
        }
    }
}