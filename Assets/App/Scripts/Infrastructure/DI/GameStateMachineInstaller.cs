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
            BindLevelSwitch();
        }

        private void BindGameStateMachine()
        {
            Container
                .Bind(typeof(IGameStateMachine), typeof(IInitializable))
                .To<GameStateMachine>()
                .AsSingle();
        }

        private void BindGameStateFactory()
        {
            Container
                .Bind<IGameStateFactory>()
                .To<GameStateFactory>()
                .AsSingle();
        }

        private void BindLevelSwitch()
        {
            Container
                .Bind<ILevelSwitch>()
                .To<LevelSwitch>()
                .AsSingle();
        }
    }
}