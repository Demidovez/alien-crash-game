using App.Scripts.Camera;
using App.Scripts.Enemy;
using App.Scripts.GamePlayer;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class Level1Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerFactory();
            BindCamera();
            BindEnemyFactory();
        }
        
        private void BindCamera()
        {
            Container
                .Bind<CameraController>()
                .FromComponentInHierarchy()
                .AsSingle();
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
