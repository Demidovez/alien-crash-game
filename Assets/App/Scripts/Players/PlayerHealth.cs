using System;
using App.Scripts.HealthPills;
using App.Scripts.UI;
using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerHealth: IDisposable
    {
        private readonly PlayerInfoUI _playerInfoUI;
        private readonly PopupManager _popupManager;
        private float _health = 100;

        public PlayerHealth(PlayerInfoUI playerInfoUI, PopupManager popupManager)
        {
            _playerInfoUI = playerInfoUI;
            _popupManager = popupManager;

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
            _health += value;
            _health = Mathf.Min(100, _health);
            
            _playerInfoUI.UpdateHealth(_health);

            if (_health <= 0)
            {
                _popupManager.ShowGameOver();
            }
        }

        public void Dispose()
        {
            HealthPill.OnCollectedHealthPill -= CollectedHealthPill;
        }
    }
}