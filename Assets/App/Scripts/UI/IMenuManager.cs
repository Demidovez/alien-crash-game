using System;

namespace App.Scripts.UI
{
    public interface IMenuManager
    {
        public event Action<string> OnLoadLevelEvent;
        public event Action OnContinueLevelEvent;
        public event Action OnStartLevelEvent;
        public event Action OnExitGameEvent;
        
        public void ShowMenu();
        public void HideMenu();
        public void OnLevelsToggle();
        public void OnContinueClick();
        public void OnStartClick();
        public void OnExitClick();
    }
}