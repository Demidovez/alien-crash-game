using App.Scripts.Infrastructure.GameStateMachines;
using App.Scripts.InputActions;
using Zenject;

namespace App.Scripts.Infrastructure
{
    public class Boot: IInitializable
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly InputActionsManager _inputActionsManager;

        public Boot(
            GameStateMachine gameStateMachine,
            InputActionsManager inputActionsManager
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