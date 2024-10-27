using App.Scripts.InputActions;
using App.Scripts.UI;
using App.Scripts.UI.Popups;
using App.Scripts.UI.Popups.Levels;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IGame _game;
        private readonly IMenuManager _menuManager;
        private readonly IInputActionsManager _inputActionsManager;
        private readonly IPopupManager _popupManager;
        private readonly ILevelsPopup _levelsPopup;

        public MenuState(
            IGameStateMachine stateMachine, 
            IGame game,
            IMenuManager menuManager,
            IInputActionsManager inputActionsManager,
            IPopupManager popupManager,
            ILevelsPopup levelsPopup
        )
        {
            _stateMachine = stateMachine;
            _game = game;
            _menuManager = menuManager;
            _inputActionsManager = inputActionsManager;
            _popupManager = popupManager;
            _levelsPopup = levelsPopup;
        }

        public void Enter()
        {
            _menuManager.ShowMenu();
            
            _menuManager.OnContinueLevelEvent += ContinueLevel;
            _menuManager.OnStartLevelEvent += StartLevel;
            _menuManager.OnLevelsShowEvent += LevelsShow;
            _menuManager.OnExitGameEvent += ExitGame;
            
            _inputActionsManager.OnCancelKeyPressed += ContinueLevel;
        }

        public void Exit()
        {
            _menuManager.HideMenu();
            
            _menuManager.OnContinueLevelEvent -= ContinueLevel;
            _menuManager.OnStartLevelEvent -= StartLevel;
            _menuManager.OnLevelsShowEvent -= LevelsShow;
            _menuManager.OnExitGameEvent -= ExitGame;
            
            _inputActionsManager.OnCancelKeyPressed -= ContinueLevel;
        }

        private void ContinueLevel()
        {
            if (_game.CurrentLevelScene != null && !_popupManager.IsActive)
            {
                _stateMachine.Enter<GameLoopState>();
            }
        }
        
        private void StartLevel()
        {
            // TODO: доработать
            _stateMachine.Enter<LoadLevelState, string>("Level_1");
        }
        
        private void LevelsShow()
        {
            _levelsPopup.Show();
        }
        
        private void ExitGame()
        {
            Debug.Log("ExitGame");
        }
    }
}