using App.Scripts.InputActions;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerInterfaceManager _playerInterfaceManager;
        private readonly InputActionsManager _inputActionsManager;

        public GameLoopState(
            GameStateMachine stateMachine, 
            PlayerInterfaceManager playerInterfaceManager,
            InputActionsManager inputActionsManager
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