using App.Scripts.Saving;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGame _game;
        private readonly ISavedData _savedData;

        public BootstrapState(
            IGameStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            IGame game,
            ISavedData savedData
        )
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _game = game;
            _savedData = savedData;
        }

        public void Enter()
        {
            _savedData.Restore();
            
            if (_sceneLoader.GetCurrentScene() != Initial)
            {
                _sceneLoader.Load(Initial, EnterLoadLevel);
            }
            else
            {
                EnterLoadLevel();
            }
        }
        
        public void Exit()
        {
            _game.Booted();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<MenuState>();
        }
    }
}