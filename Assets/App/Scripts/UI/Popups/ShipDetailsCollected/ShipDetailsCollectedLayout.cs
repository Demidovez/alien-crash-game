using System;
using UnityEngine;

namespace App.Scripts.UI.Popups.ShipDetailsCollected
{
    public class ShipDetailsCollectedLayout: MonoBehaviour
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