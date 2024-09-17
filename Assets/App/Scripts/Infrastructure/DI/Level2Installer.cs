using App.Scripts.Enemy;
using App.Scripts.PlayerGame;
using App.Scripts.ShipDetail;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class Level2Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerFactory();
            BindEnemyFactory();
            BindShipDetailFactory();
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
        
        private void BindShipDetailFactory()
        {
            Container
                .Bind<IShipDetailFactory>()
                .To<ShipDetailFactory>()
                .AsSingle();
        }
    }
}
