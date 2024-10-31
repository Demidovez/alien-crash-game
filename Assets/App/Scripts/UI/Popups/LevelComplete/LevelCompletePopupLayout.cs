using System;
using UnityEngine;

namespace App.Scripts.UI.Popups.LevelComplete
{
    public class LevelCompletePopupLayout: MonoBehaviour
    {
        public Action OnOkClick;
        
        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnOkClick?.Invoke();
            }
        }

        public void OnOkClickListener()
        {
            OnOkClick?.Invoke();
        }
    }
}