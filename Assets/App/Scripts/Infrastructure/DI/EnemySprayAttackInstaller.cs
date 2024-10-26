using App.Scripts.Enemies;
using App.Scripts.Weapon;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemySprayAttackInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemySpray();
            BindEnemySprayAttack();
        }

        private void BindEnemySpray()
        {
            Container
                .Bind<IEnemySpray>()
                .To<EnemySpray>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemySprayAttack()
        {
            Container
                .BindInterfacesTo<EnemySprayAttack>()
                .AsSingle();
        }
    }
}