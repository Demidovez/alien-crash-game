using System;

namespace App.Scripts.UI
{
    public interface IMenuManager
    {
        public event Action OnBackToLevelEvent;
        public event Action OnStartLevelEvent;
        public event Action OnLevelsShowEvent;
        public event Action OnExitGameEvent;
        
        public void ShowMenu();
        public void HideMenu();
        public void OnLevelsClick();
        public void OnBackClick();
        public void OnStartClick();
        public void OnExitClick();
    }
}