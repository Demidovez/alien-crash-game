using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI
{
    public class PlayerInterfaceManager : MonoBehaviour, IPlayerInterfaceManager
    {
        public Transform HealthLevel;
        public Transform ShipDetails;
        public Transform WeaponAim;
        public TMP_Text ShipDetailCountText;
        public Image HealthBarLevel;

        private int _countAllDetails;
        
        private void OnEnable()
        {
            SetVisible(false);
        }

        public void Reset()
        {
            HealthBarLevel.rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        }

        public void SetVisible(bool isVisible)
        {
            HealthLevel.gameObject.SetActive(isVisible);
            ShipDetails.gameObject.SetActive(isVisible && _countAllDetails > 0);
            WeaponAim.gameObject.SetActive(isVisible);
        }

        public void UpdateHealth(float value)
        {
            float newPositionX = -HealthBarLevel.rectTransform.sizeDelta.x * (1 - (value / 100f));
            HealthBarLevel.rectTransform.localPosition = new Vector3(newPositionX, 0f, 0f);
        }
        
        public void UpdateShipDetailsCounter(int countCollected, int countAllDetails)
        {
            _countAllDetails = countAllDetails;
            
            if (_countAllDetails == 0)
            {
                ShipDetails.gameObject.SetActive(false);
                return;
            }
            
            ShipDetailCountText.text = $"{countCollected} / {countAllDetails}";
        }
    }
}