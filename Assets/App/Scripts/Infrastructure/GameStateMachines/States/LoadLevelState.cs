using App.Scripts.Levels;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class LoadLevelState : IPayloadedState<Level>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingScreen _loadingScreen;

        public LoadLevelState(
            IGameStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            ILoadingScreen loadingScreen
        ) 
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
        }

        public void Enter(Level level)
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            _loadingScreen.Show();
            _sceneLoader.Load(level.Scene.name, OnLoaded);
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