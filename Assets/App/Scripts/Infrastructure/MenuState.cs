using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class MenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly MenuManager _menuManager;

        public MenuState(
            GameStateMachine stateMachine, 
            MenuManager menuManager
        )
        {
            _stateMachine = stateMachine;
            _menuManager = menuManager;
        }

        public void Enter()
        {
            _menuManager.ShowMenu();
            
            _menuManager.OnLoadLevelEvent += LoadLevel;
        }

        public void Exit()
        {
            _menuManager.HideMenu();
            
            _menuManager.OnLoadLevelEvent -= LoadLevel;
        }
        
        private void LoadLevel(string level)
        {
            Debug.Log("Load Level: " + level);
        }
    }
}