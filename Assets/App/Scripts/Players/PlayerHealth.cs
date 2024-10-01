using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerHealth
    {
        private float _health = 100;

        public void TryTakeDamage(float value)
        {
            _health -= value;
            
            Debug.Log("Health: " + _health);
        }
    }
}