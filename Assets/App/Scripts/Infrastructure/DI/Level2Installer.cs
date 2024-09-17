using App.Scripts.Enemy;
using App.Scripts.PlayerGame;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class Level2Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerFactory();
            BindEnemyFactory();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindPlayerFactory()
        {
            Container
                .Bind<IPlayerFactory>()
                .To<PlayerFactory>()
                .AsSingle();
        }
    }
}
