using System;

namespace App.Scripts.Players
{
    public class PlayerShooting : IDisposable
    {
        private readonly PlayerHealth _playerHealth;

        public PlayerShooting(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;

            _playerHealth.OnDeadEvent += OnDead;
        }

        private void OnDead()
        {

        }

        public void Dispose()
        {
            _playerHealth.OnDeadEvent -= OnDead;
        }
    }
}