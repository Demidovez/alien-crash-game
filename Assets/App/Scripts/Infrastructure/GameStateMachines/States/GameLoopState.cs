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
            _playerInterfaceManager.SetVisible(true);

            _inputActionsManager.OnToggleMenu += ShowMenu;
        }

        public void Exit()
        {
            Cursor.lockState = CursorLockMode.None;
            
            _playerInterfaceManager.SetVisible(false);
            
            _inputActionsManager.OnToggleMenu -= ShowMenu;
        }

        private void ShowMenu()
        {
            _stateMachine.Enter<MenuState>();
        }
    }
}