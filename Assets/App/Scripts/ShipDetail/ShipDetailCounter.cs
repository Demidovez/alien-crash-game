using App.Scripts.UI;
using App.Scripts.UI.Popups;
using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailCounter : IShipDetailCounter
    {
        private int _countAllDetails;
        private int _countCollected;

        private readonly IPopupManager _popupManager;
        private readonly IPlayerInterfaceManager _playerInterfaceManager;

        public ShipDetailCounter(
            IPopupManager popupManager,
            IPlayerInterfaceManager playerInterfaceManager
        )
        {
            _popupManager = popupManager;
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
                // _popupManager.ShowCompleteCollectDetails();
                Debug.Log("CollectedDetail");
            }
        }
    }
}