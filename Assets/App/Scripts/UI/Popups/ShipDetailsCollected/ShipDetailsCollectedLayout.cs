using System;
using TMPro;
using UnityEngine;

namespace App.Scripts.UI.Popups.ShipDetailsCollected
{
    public class ShipDetailsCollectedLayout: MonoBehaviour
    {
        internal string Text;
        
        public TextMeshProUGUI TextMeshPro;
        public Action OnOkClick;
        
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