using App.Scripts.InputActions;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IPlayerInterfaceManager _playerInterfaceManager;
        private readonly IInputActionsManager _inputActionsManager;

        public GameLoopState(
            IGameStateMachine stateMachine, 
            IPlayerInterfaceManager playerInterfaceManager,
            IInputActionsManager inputActionsManager
        )
        {
            _stateMachine = stateMachine;
            _playerInterfaceManager = playerInterfaceManager;
            _inputActionsManager = inputActionsManager;
        }
        
        public void Enter()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            
            _playerInterfaceManager.SetVisible(true);

            _inputActionsManager.OnCancelKeyPressed += CancelKeyPressed;
        }

        public void Exit()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
            _playerInterfaceManager.SetVisible(false);
            
            _inputActionsManager.OnCancelKeyPressed -= CancelKeyPressed;
        }

        private void CancelKeyPressed()
        {
            _stateMachine.Enter<MenuState>();
        }
    }
}