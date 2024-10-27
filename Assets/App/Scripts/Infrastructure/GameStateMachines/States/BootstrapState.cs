namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGame _game;

        public BootstrapState(
            IGameStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            IGame game
        )
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _game = game;
        }

        public void Enter()
        {
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
            // Достаем сохранения и идем в меню
            _stateMachine.Enter<MenuState>();
        }
    }
}