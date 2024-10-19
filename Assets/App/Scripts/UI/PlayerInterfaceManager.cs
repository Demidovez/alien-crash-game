﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI
{
    public class PlayerInterfaceManager : MonoBehaviour
    {
        public Transform HealthLevel;
        public Transform ShipDetails;
        public Transform WeaponAim;
        public TMP_Text ShipDetailCountText;
        public Image HealthBarLevel;

        private void Awake()
        {
            SetVisible(false);
        }

        public void SetVisible(bool isVisible)
        {
            HealthLevel.gameObject.SetActive(isVisible);
            ShipDetails.gameObject.SetActive(isVisible);
            WeaponAim.gameObject.SetActive(isVisible);
        }

        public void UpdateHealth(float value)
        {
            float newPositionX = - HealthBarLevel.rectTransform.sizeDelta.x * (1 - (value / 100f));
            HealthBarLevel.rectTransform.localPosition = new Vector3(newPositionX, 0f, 0f);
        }
        
        public void UpdateShipDetailsCounter(int countCollected, int countAllDetails)
        {
            ShipDetailCountText.text = $"{countCollected} / {countAllDetails}";
        }
    }
}