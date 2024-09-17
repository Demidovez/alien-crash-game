using App.Scripts.Enemy;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class Level2Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemyFactory();
        }
        
        private void BindEnemyFactory()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}
