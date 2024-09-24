using App.Scripts.Enemy;
using App.Scripts.PlayerGame;
using App.Scripts.ShipDetail;
using TMPro;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class Level1Installer : MonoInstaller
    {
        public TMP_Text ShipDetailCountText;
        
        public override void InstallBindings()
        {
            BindPlayerFactory();
            BindEnemyFactory();
            BindShipDetailFactory();
            BindShipDetailsCounter();
        }

        private void BindShipDetailsCounter()
        {
            Container
                .BindInterfacesAndSelfTo<ShipDetailCounter>()
                .AsSingle()
                .WithArguments(ShipDetailCountText);
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
