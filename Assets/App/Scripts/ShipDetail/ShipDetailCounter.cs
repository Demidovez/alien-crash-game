using System;
using App.Scripts.UI;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailCounter : IDisposable
    {
        private int _countAllDetails;
        private int _countCollected;

        private readonly PopupManager _popupManager;
        private readonly PlayerInterfaceManager _playerInterfaceManager;

        public ShipDetailCounter(
            PopupManager popupManager,
            PlayerInterfaceManager playerInterfaceManager
        )
        {
            _popupManager = popupManager;
            _playerInterfaceManager = playerInterfaceManager;

            ShipDetail.OnCollectedShipDetail += CollectedDetail;
        }
        
        public void Dispose()
        {
            ShipDetail.OnCollectedShipDetail -= CollectedDetail;
        }

        public void SetCountAll(int value)
        {
            _countAllDetails = value;
            _playerInterfaceManager.UpdateShipDetailsCounter(0, _countAllDetails);
        }

        private void CollectedDetail()
        {
            _countCollected++;
            
            _playerInterfaceManager.UpdateShipDetailsCounter(_countCollected, _countAllDetails);

            if (_countAllDetails == _countCollected)
            {
                _popupManager.ShowCompleteCollectDetails();
            }
        }
    }
}