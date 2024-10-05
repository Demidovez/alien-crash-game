using System;

namespace App.Scripts.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly UIManager _uiManager;

        public GameLoopState(GameStateMachine stateMachine, UIManager uiManager)
        {
            _uiManager = uiManager;
        }

        public void Exit()
        {
            _uiManager.SetVisibleHealthLevel(false);
            _uiManager.SetVisibleShipDetails(false);
            _uiManager.SetVisibleWeaponAim(false);
        }

        public void Enter()
        {
            _uiManager.SetVisibleHealthLevel(true);
            _uiManager.SetVisibleShipDetails(true);
            _uiManager.SetVisibleWeaponAim(true);
        }
    }
}