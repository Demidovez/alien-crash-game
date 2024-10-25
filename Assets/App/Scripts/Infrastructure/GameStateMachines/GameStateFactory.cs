using Zenject;

namespace App.Scripts.Infrastructure.GameStateMachines
{
    public class GameStateFactory
    {
        private readonly DiContainer _diContainer;
        
        public GameStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TState Create<TState>() where TState : class, IExitableState
        {
            return _diContainer.Instantiate<TState>();
        }
    }
}