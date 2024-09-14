using App.Scripts.GamePlayer;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerMovement();
        }

        private void BindPlayerMovement()
        {
            Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        }
    }
}