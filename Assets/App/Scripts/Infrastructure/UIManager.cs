using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure
{
    public class UIManager : MonoBehaviour
    {
        public Transform HealthLevel;
        public Transform ShipDetails;
        public Transform WeaponAim;
        
        public Image HealthBarLevel;

        private void Awake()
        {
            HealthLevel.gameObject.SetActive(false);
            ShipDetails.gameObject.SetActive(false);
            WeaponAim.gameObject.SetActive(false);
        }

        public void SetVisibleHealthLevel(bool isVisible)
        {
            HealthLevel.gameObject.SetActive(isVisible);
        }

        public void SetVisibleShipDetails(bool isVisible)
        {
            ShipDetails.gameObject.SetActive(isVisible);
        }

        public void SetVisibleWeaponAim(bool isVisible)
        {
            WeaponAim.gameObject.SetActive(isVisible);
        }

        public void UpdateHealth(float value)
        {
            float newPositionX = - HealthBarLevel.rectTransform.sizeDelta.x * (1 - (value / 100f));
            HealthBarLevel.rectTransform.localPosition = new Vector3(newPositionX, 0f, 0f);
        }
    }
}