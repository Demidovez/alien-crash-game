using System;
using System.Collections;
using App.Scripts.Infrastructure;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerHealth: IPlayerHealth
    {
        public event Action OnTookDamageEvent;
        public event Action OnDeadEvent;
        
        public bool IsAlive => _health > 0;
        
        private readonly IPopupManager _popupManager;
        private readonly ICoroutineHolder _coroutineHolder;
        private readonly IPlayerInterfaceManager _playerInterfaceManager;
        private const float DeathDelay = 2f;
        private float _health = 100;

        public PlayerHealth(
            IPopupManager popupManager,
            ICoroutineHolder coroutineHolder,
            IPlayerInterfaceManager playerInterfaceManager
        )
        {
            _popupManager = popupManager;
            _coroutineHolder = coroutineHolder;
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
                _coroutineHolder.StartCoroutine(Death());
            }
            else if(value < -0.1f)
            {
                OnTookDamageEvent?.Invoke();
            }
        }
        
        private IEnumerator Death()
        {
            yield return new WaitForSeconds(DeathDelay);
            _popupManager.ShowGameOver();
        }
    }
}