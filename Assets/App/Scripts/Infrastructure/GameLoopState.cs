using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly PlayerInterfaceManager _playerInterfaceManager;

        public GameLoopState(GameStateMachine stateMachine, PlayerInterfaceManager playerInterfaceManager)
        {
            _playerInterfaceManager = playerInterfaceManager;
        }
        
        public void Enter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            _playerInterfaceManager.SetVisible(true);
        }

        public void Exit()
        {
            Cursor.lockState = CursorLockMode.None;
            
            _playerInterfaceManager.SetVisible(false);
        }
    }
}