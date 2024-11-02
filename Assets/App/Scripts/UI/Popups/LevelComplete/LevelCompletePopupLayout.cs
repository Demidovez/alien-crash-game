using System;
using TMPro;
using UnityEngine;

namespace App.Scripts.UI.Popups.LevelComplete
{
    public class LevelCompletePopupLayout: MonoBehaviour
    {
        internal string Text;
        
        public TextMeshProUGUI TextMeshPro;
        public Action OnMenuClick;
        public Action OnNextClick;

        private bool _isWaiting = true;

        private void OnEnable()
        {
            TextMeshPro.SetText(Text);
        }
        
        private void OnDisable()
        {
            TextMeshPro.SetText("");
        }

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