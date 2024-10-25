using App.Scripts.InputActions;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class MenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly Game _game;
        private readonly MenuManager _menuManager;
        private readonly InputActionsManager _inputActionsManager;

        public MenuState(
            GameStateMachine stateMachine, 
            Game game,
            MenuManager menuManager,
            InputActionsManager inputActionsManager
        )
        {
            _stateMachine = stateMachine;
            _game = game;
            _menuManager = menuManager;
            _inputActionsManager = inputActionsManager;
        }

        public void Enter()
        {
            Time.timeScale = 0;
            _menuManager.ShowMenu();
            
            _menuManager.OnLoadLevelEvent += LoadLevel;
            _menuManager.OnContinueLevelEvent += ContinueLevel;
            _menuManager.OnStartLevelEvent += StartLevel;
            _menuManager.OnExitGameEvent += ExitGame;
            
            _inputActionsManager.OnToggleMenu += ContinueLevel;
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _menuManager.HideMenu();
            
            _menuManager.OnLoadLevelEvent -= LoadLevel;
            _menuManager.OnContinueLevelEvent -= ContinueLevel;
            _menuManager.OnStartLevelEvent -= StartLevel;
            _menuManager.OnExitGameEvent -= ExitGame;
            
            _inputActionsManager.OnToggleMenu -= ContinueLevel;
        }
        
        private void LoadLevel(string level)
        {
            _stateMachine.Enter<LoadLevelState, string>("Level_1");
        }

        private void ContinueLevel()
        {
            if (_game.CurrentLevelScene != null)
            {
                _stateMachine.Enter<GameLoopState>();
            }
        }
        
        private void StartLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("Level_1");
        }
        
        private void ExitGame()
        {
            Debug.Log("ExitGame");
        }
    }
}