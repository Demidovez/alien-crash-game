using App.Scripts.UI;
using App.Scripts.UI.Popups.ShipDetailsCollected;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailCounter : IShipDetailCounter
    {
        private int _countAllDetails;
        private int _countCollected;
        
        private readonly IPlayerInterfaceManager _playerInterfaceManager;
        private readonly IShipDetailsCollectedPopup _shipDetailsCollectedPopup;

        public ShipDetailCounter(
            IPlayerInterfaceManager playerInterfaceManager,
            IShipDetailsCollectedPopup shipDetailsCollectedPopup
        )
        {
            _playerInterfaceManager = playerInterfaceManager;
            _shipDetailsCollectedPopup = shipDetailsCollectedPopup;
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
                _shipDetailsCollectedPopup.Show("Вы уверены?","Прогресс игры не сохранится!", "Выйти", () => { });
            }
        }
    }
}