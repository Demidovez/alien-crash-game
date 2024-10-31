using System;
using App.Scripts.UI;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailCounter : IShipDetailCounter
    {
        public event Action OnShipDetailsCollectedEvent; 
        
        private int _countAllDetails;
        private int _countCollected;
        
        private readonly IPlayerInterfaceManager _playerInterfaceManager;

        public ShipDetailCounter(
            IPlayerInterfaceManager playerInterfaceManager
        )
        {
            _playerInterfaceManager = playerInterfaceManager;
        }

        public void SetCountAll(int value)
        {
            _countAllDetails = value;
            _playerInterfaceManager.UpdateShipDetailsCounter(0, _countAllDetails);
        }

        public void CollectedDetail()
        {
            _countCollected++;
            
            _playerInterfaceManager.UpdateShipDetailsCounter(_countCollected, _countAllDetails);

            if (_countAllDetails == _countCollected)
            {
                OnShipDetailsCollectedEvent?.Invoke();
            }
        }
    }
}