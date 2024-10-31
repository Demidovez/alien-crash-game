using System;
using UnityEngine;

namespace App.Scripts.UI
{
    public class MenuManager : MonoBehaviour, IMenuManager
    {
        public event Action OnContinueLevelEvent;
        public event Action OnStartLevelEvent;
        public event Action OnLevelsShowEvent;
        public event Action OnExitGameEvent;
        
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ShowMenu()
        {
            gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            gameObject.SetActive(false);
        }

        public void OnLevelsClick()
        {
            OnLevelsShowEvent?.Invoke();
        }

        public void OnContinueClick()
        {
            OnContinueLevelEvent?.Invoke();
        }

        public void OnStartClick()
        {
            OnStartLevelEvent?.Invoke();
        }

        public void OnExitClick()
        {
            OnExitGameEvent?.Invoke();
        }
    }
}