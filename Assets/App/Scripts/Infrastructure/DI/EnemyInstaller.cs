using App.Scripts.Components;
using App.Scripts.Enemy;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFieldOfView();
            BindEnemyMovement();
            BindEnemyChaseManager();
        }

        private void BindFieldOfView()
        {
            Container.Bind<FieldOfView>().FromComponentInHierarchy().AsSingle();
        }
        
        private void BindEnemyMovement()
        {
            Container.Bind<EnemyMovement>().FromComponentInHierarchy().AsSingle();
        }

        private void BindEnemyChaseManager()
        {
            Container.BindInterfacesAndSelfTo<EnemyChaseManager>().AsSingle().NonLazy();
        }
    }
}