using App.Scripts.InputActions;
using App.Scripts.UI;
using App.Scripts.UI.Popups;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IPlayerInterfaceManager _playerInterfaceManager;
        private readonly IInputActionsManager _inputActionsManager;
        private readonly IPopupManager _popupManager;
        private readonly IGame _game;

        public GameLoopState(
            IGameStateMachine stateMachine, 
            IPlayerInterfaceManager playerInterfaceManager,
            IInputActionsManager inputActionsManager,
            IPopupManager popupManager,
            IGame game
        )
        {
            _stateMachine = stateMachine;
            _playerInterfaceManager = playerInterfaceManager;
            _inputActionsManager = inputActionsManager;
            _popupManager = popupManager;
            _game = game;
        }
        
        public void Enter()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            _game.SetIsGameState(true);
            
            _playerInterfaceManager.SetVisible(true);

            _inputActionsManager.OnCancelKeyPressed += CancelKeyPressed;
        }

        public void Exit()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            _game.SetIsGameState(false);
            
            _playerInterfaceManager.SetVisible(false);
            
            _inputActionsManager.OnCancelKeyPressed -= CancelKeyPressed;
        }

        private void CancelKeyPressed()
        {
            if (!_popupManager.IsActive)
            {
                _stateMachine.Enter<MenuState>();
            }
        }
    }
}