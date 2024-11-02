using System;
using UnityEngine;

namespace App.Scripts.UI.Popups.GameOver
{
    public class GameOverPopupLayout: MonoBehaviour
    {
        public Action OnMenuClick;
        public Action OnAgainClick;

        private bool _isWaiting = true;

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return) && _isWaiting)
            {
                _isWaiting = false;
                OnAgainClick?.Invoke();
            }
        }
        
        public void OnMenuClickListener()
        {
            OnMenuClick?.Invoke();
        }

        public void OnAgainClickListener()
        {
            OnAgainClick?.Invoke();
        }
    }
}