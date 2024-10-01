using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Players
{
    public class PlayerInfoUI
    {
        private readonly Image _healthBarLevel;

        public PlayerInfoUI(Image healthBarLevel)
        {
            _healthBarLevel = healthBarLevel;
        }
        
        public void UpdateHealth(float value)
        {
            float newPositionX = - _healthBarLevel.rectTransform.sizeDelta.x * (1 - (value / 100f));
            _healthBarLevel.rectTransform.localPosition = new Vector3(newPositionX, 0f, 0f);
        }
    }
}