using App.Scripts.Enemies;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemySprayAttackInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemySpray();
        }

        private void BindEnemySpray()
        {
            Container
                .Bind<IAttackMode>()
                .To<EnemySprayAttack>()
                .AsSingle();
        }
    }
}