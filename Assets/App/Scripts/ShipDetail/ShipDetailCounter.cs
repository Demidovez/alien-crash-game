using System;
using App.Scripts.UI;
using TMPro;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailCounter : IDisposable
    {
        private int _countAllDetails;
        private int _countCollected;
        private readonly TMP_Text _shipDetailCountText;
        private readonly PopupManager _popupManager;

        public ShipDetailCounter(TMP_Text shipDetailCountText, PopupManager popupManager)
        {
            _shipDetailCountText = shipDetailCountText;
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
            UpdateTextCounter();
        }

        private void CollectedDetail()
        {
            _countCollected++;
            
            UpdateTextCounter();

            if (_countAllDetails == _countCollected)
            {
                _popupManager.ShowCompleteCollectDetails();
            }
        }

        private void UpdateTextCounter()
        {
            _shipDetailCountText.text = $"{_countCollected} / {_countAllDetails}";
        }
    }
}