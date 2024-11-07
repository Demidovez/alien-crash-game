using System;
using System.Collections;
using App.Scripts.Infrastructure;
using App.Scripts.UI;
using App.Scripts.UI.Popups.GameOver;
using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerHealth: IPlayerHealth
    {
        public event Action OnTookDamageEvent;
        public event Action OnDeadEvent;
        public event Action OnAliveEvent;
        
        public bool IsAlive => _health > 0;
        
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly IGameOverPopup _gameOverPopup;
        private readonly IPlayerInterfaceManager _playerInterfaceManager;
        private const float DeathDelay = 2f;
        private float _health = 100f;

        public PlayerHealth(
            IGameObjectHolder gameObjectHolder,
            IGameOverPopup gameOverPopup,
            IPlayerInterfaceManager playerInterfaceManager
        )
        {
            _gameObjectHolder = gameObjectHolder;
            _gameOverPopup = gameOverPopup;
            _playerInterfaceManager = playerInterfaceManager;
        }

        public void TryTakeDamage(float value)
        {
            UpdateHealth(-value);
        }
        
        public void TryRegenerate(float value)
        {
            UpdateHealth(value);
        }

        public void TryAlive()
        {
            _health = 0f;
            OnAliveEvent?.Invoke();

            _gameObjectHolder.StartCoroutine(RestoreHealth());
        }

        private IEnumerator RestoreHealth()
        {
            yield return new WaitForSeconds(3.5f);
            _health = 100f;
        }

        private void UpdateHealth(float value)
        {
            if (_health <= 0)
            {
                return;
            }
            
            _health += value;
            _health = Mathf.Min(100, _health);
            
            _playerInterfaceManager.UpdateHealth(_health);

            if (_health <= 0)
            {
                OnDeadEvent?.Invoke();
                _gameObjectHolder.StartCoroutine(Death());
            }
            else if(value < -0.1f)
            {
                OnTookDamageEvent?.Invoke();
            }
        }
        
        private IEnumerator Death()
        {
            yield return new WaitForSeconds(DeathDelay);
            _gameOverPopup.Show();
        }
    }
}