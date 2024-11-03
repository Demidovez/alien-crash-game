using System;
using App.Scripts.InputActions;
using App.Scripts.Weapon;

namespace App.Scripts.Players
{
    public class PlayerShooting : IPlayerShooting, IDisposable
    {
        public event Action OnShootEvent;
        
        private readonly IPlayerHealth _playerHealth;
        private readonly IInputActionsManager _inputActionsManager;
        private readonly IPlayerBlaster _playerBlaster;

        public PlayerShooting(
            IPlayerHealth playerHealth, 
            IInputActionsManager inputActionsManager,
            IPlayerBlaster playerBlaster
        )
        {
            _playerHealth = playerHealth;
            _inputActionsManager = inputActionsManager;
            _playerBlaster = playerBlaster;
            
            _inputActionsManager.OnInputtedShoot += Shoot;
        }

        private void Shoot()
        {
            if (!_playerHealth.IsAlive)
            {
                return;
            }
            
            _playerBlaster.Shoot();
                
            OnShootEvent?.Invoke();
        }

        public void Dispose()
        {
            _inputActionsManager.OnInputtedShoot -= Shoot;
        }
    }
}