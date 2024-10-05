using System;
using System.Collections;
using App.Scripts.HealthPills;
using App.Scripts.Infrastructure;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerHealth: IDisposable
    {
        public Action OnTookDamageEvent;
        public Action OnDeadEvent;
        
        private readonly PlayerInfoUI _playerInfoUI;
        private readonly PopupManager _popupManager;
        private readonly AsyncProcessor _asyncProcessor;
        private const float DeathDelay = 2f;
        private float _health = 100;

        public PlayerHealth(
            PlayerInfoUI playerInfoUI, 
            PopupManager popupManager,
            AsyncProcessor asyncProcessor
        )
        {
            _playerInfoUI = playerInfoUI;
            _popupManager = popupManager;
            _asyncProcessor = asyncProcessor;

            HealthPill.OnCollectedHealthPill += CollectedHealthPill;
        }

        private void CollectedHealthPill()
        {
            UpdateHealth(10);
        }

        public void TryTakeDamage(float value)
        {
            UpdateHealth(-value);
        }

        private void UpdateHealth(float value)
        {
            if (_health <= 0)
            {
                return;
            }
            
            _health += value;
            _health = Mathf.Min(100, _health);
            
            _playerInfoUI.UpdateHealth(_health);

            if (_health <= 0)
            {
                OnDeadEvent?.Invoke();
                _asyncProcessor.StartCoroutine(Death());
            }
            else
            {
                OnTookDamageEvent?.Invoke();
            }
        }
        
        IEnumerator Death()
        {
            yield return new WaitForSeconds(DeathDelay);
            _popupManager.ShowGameOver();
        }

        public void Dispose()
        {
            HealthPill.OnCollectedHealthPill -= CollectedHealthPill;
        }
    }
}