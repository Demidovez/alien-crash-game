using System;
using App.Scripts.Infrastructure;
using App.Scripts.UI;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailCounter : IDisposable
    {
        private int _countAllDetails;
        private int _countCollected;
        private readonly Game _game;
        private readonly PopupManager _popupManager;

        public ShipDetailCounter(Game game, PopupManager popupManager)
        {
            _game = game;
            _popupManager = popupManager;

            ShipDetail.OnCollectedShipDetail += CollectedDetail;
        }
        
        public void Dispose()
        {
            ShipDetail.OnCollectedShipDetail -= CollectedDetail;
        }

        public void SetCountAll(int value)
        {
            _countAllDetails = value;
            _game.UpdateShipDetailsUI(0, _countAllDetails);
        }

        private void CollectedDetail()
        {
            _countCollected++;
            
            _game.UpdateShipDetailsUI(_countCollected, _countAllDetails);

            if (_countAllDetails == _countCollected)
            {
                _popupManager.ShowCompleteCollectDetails();
            }
        }
    }
}