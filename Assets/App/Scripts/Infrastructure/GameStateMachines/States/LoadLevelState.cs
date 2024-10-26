using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingScreen _loadingScreen;
        private readonly IGame _game;

        public LoadLevelState(
            IGameStateMachine stateMachine, 
            IGame game,
            ISceneLoader sceneLoader,
            ILoadingScreen loadingScreen
        ) 
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
            _game = game;
        }

        public void Enter(string nameScene)
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            _loadingScreen.Show();
            _sceneLoader.Load(nameScene, OnLoaded);
            _game.SetCurrentLevelScene(nameScene);
        }
        
        public void Exit()
        {
            _loadingScreen.Hide();
        }
        
        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}