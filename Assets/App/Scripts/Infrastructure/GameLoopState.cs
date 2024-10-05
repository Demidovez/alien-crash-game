using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly UIManager _uiManager;

        public GameLoopState(GameStateMachine stateMachine, UIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void Enter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            _uiManager.SetVisibleHealthLevel(true);
            _uiManager.SetVisibleShipDetails(true);
            _uiManager.SetVisibleWeaponAim(true);
        }

        public void Exit()
        {
            Cursor.lockState = CursorLockMode.None;
            
            _uiManager.SetVisibleHealthLevel(false);
            _uiManager.SetVisibleShipDetails(false);
            _uiManager.SetVisibleWeaponAim(false);
        }
    }
}