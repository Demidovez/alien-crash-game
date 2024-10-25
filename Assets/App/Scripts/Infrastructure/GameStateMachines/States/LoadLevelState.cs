using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingScreen _loadingScreen;
        private readonly Game _game;

        public LoadLevelState(
            GameStateMachine stateMachine, 
            Game game,
            SceneLoader sceneLoader,
            LoadingScreen loadingScreen
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