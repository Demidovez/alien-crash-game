using App.Scripts.Infrastructure.GameStateMachines;
using App.Scripts.InputActions;
using Zenject;

namespace App.Scripts.Infrastructure
{
    public class Boot: IInitializable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IInputActionsManager _inputActionsManager;

        public Boot(
            IGameStateMachine gameStateMachine,
            IInputActionsManager inputActionsManager
        )
        {
            _gameStateMachine = gameStateMachine;
            _inputActionsManager = inputActionsManager;
        }
        
        public void Initialize()
        {
            _inputActionsManager.Boot();
            _gameStateMachine.Boot();
        }
    }
}