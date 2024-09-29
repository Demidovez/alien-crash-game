using App.Scripts.Players;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerMovement();
            BindPlayerHealth();
        }

        private void BindPlayerHealth()
        {
            Container.Bind<PlayerHealth>().AsSingle();
        }

        private void BindPlayerMovement()
        {
            Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        }
    }
}