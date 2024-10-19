namespace App.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
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

        private void EnterLoadLevel()
        {
            // Достаем сохранения и едем в меню
            _stateMachine.Enter<MenuState>();
            
            // _stateMachine.Enter<LoadLevelState, string>("Level_3");
        }

        public void Exit()
        {
        }
    }
}