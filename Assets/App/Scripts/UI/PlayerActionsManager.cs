using TMPro;
using UnityEngine;

namespace App.Scripts.UI
{
    public class PlayerActionsManager: MonoBehaviour, IPlayerActionsManager
    {
        [Header("Fix Space Ship")] 
        public Transform FixContainer;
        public TMP_Text FixValue;
        
        public string FixCurrentValue {
            set => FixValue.SetText(value);
        }

        private void Awake()
        {
            FixContainer.gameObject.SetActive(false);
        }

        public void SetActivateFixing(bool isActive)
        {
            FixContainer.gameObject.SetActive(isActive);
        }
    }
}