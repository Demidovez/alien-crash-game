using App.Scripts.Infrastructure.GameStateMachines;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindGameStateFactory();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GameStateMachine>().AsSingle();
        }
        
        private void BindGameStateFactory()
        {
            Container.Bind<GameStateFactory>().AsSingle();
        }
    }
}