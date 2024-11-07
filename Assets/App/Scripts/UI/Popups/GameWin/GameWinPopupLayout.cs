using System;
using UnityEngine;

namespace App.Scripts.UI.Popups.GameWin
{
    public class GameWinPopupLayout: MonoBehaviour
    {
        public Action OnFinishClick;

        private bool _isWaiting = true;

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return) && _isWaiting)
            {
                _isWaiting = false;
                OnFinishClick?.Invoke();
            }
        }
        
        public void OnFinishClickListener()
        {
            OnFinishClick?.Invoke();
        }
    }
}