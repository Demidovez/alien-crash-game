using System;
using UnityEngine;

namespace App.Scripts.UI.Popups.LevelComplete
{
    public class LevelCompletePopupLayout: MonoBehaviour
    {
        public Action OnMenuClick;
        public Action OnNextClick;

        private bool _isWaiting = true;
        
        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return) && _isWaiting)
            {
                _isWaiting = false;
                OnNextClick?.Invoke();
            }
        }
        
        public void OnMenuClickListener()
        {
            OnMenuClick?.Invoke();
        }

        public void OnNextClickListener()
        {
            OnNextClick?.Invoke();
        }
    }
}