namespace App.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(
            GameStateMachine stateMachine, 
            SceneLoader sceneLoader
        ) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string nameScene)
        {
            _sceneLoader.Load(nameScene, OnLoaded);
        }
        
        public void Exit()
        {
            
        }
        
        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}