using System;
using App.Scripts.ShipDetail;
using App.Scripts.Teleports;
using App.Scripts.UI.Popups.LevelComplete;
using App.Scripts.UI.Popups.ShipDetailsCollected;
using Zenject;

namespace App.Scripts.LevelControllers
{
    public class LevelController: ILevelController, IInitializable, IDisposable
    {
        private readonly IShipDetailCounter _shipDetailCounter;
        private readonly IShipDetailsCollectedPopup _shipDetailsCollectedPopup;
        private readonly ILevelCompletePopup _levelCompletePopup;
        private readonly ITeleport _teleport;

        public LevelController(
            IShipDetailCounter shipDetailCounter,
            IShipDetailsCollectedPopup shipDetailsCollectedPopup,
            ILevelCompletePopup levelCompletePopup,
            ITeleport teleport
        )
        {
            _shipDetailCounter = shipDetailCounter;
            _shipDetailsCollectedPopup = shipDetailsCollectedPopup;
            _levelCompletePopup = levelCompletePopup;
            _teleport = teleport;
        }
        
        public void Initialize()
        {
            _shipDetailCounter.OnShipDetailsCollectedEvent += CollectedDetails;
            _teleport.OnTeleportedEvent += EnteredTeleport;
        }

        public void Dispose()
        {
            _shipDetailCounter.OnShipDetailsCollectedEvent -= CollectedDetails;
            _teleport.OnTeleportedEvent -= EnteredTeleport;
        }

        private void CollectedDetails()
        {
            _teleport.SetActiveStatus(true);
            _shipDetailsCollectedPopup.Show();
        }
        
        private void EnteredTeleport()
        {
            _levelCompletePopup.Show();
        }
    }
}