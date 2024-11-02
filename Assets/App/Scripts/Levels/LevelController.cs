using System;
using App.Scripts.ShipDetail;
using App.Scripts.Teleports;
using App.Scripts.UI.Popups.LevelComplete;
using App.Scripts.UI.Popups.ShipDetailsCollected;
using Zenject;

namespace App.Scripts.Levels
{
    public class LevelController: ILevelController, IInitializable, IDisposable
    {
        private readonly IShipDetailCounter _shipDetailCounter;
        private readonly IShipDetailsCollectedPopup _shipDetailsCollectedPopup;
        private readonly ILevelCompletePopup _levelCompletePopup;
        private readonly ITeleport _teleport;
        private readonly ILevelsManager _levelsManager;

        public LevelController(
            IShipDetailCounter shipDetailCounter,
            IShipDetailsCollectedPopup shipDetailsCollectedPopup,
            ILevelCompletePopup levelCompletePopup,
            ITeleport teleport,
            ILevelsManager levelsManager
        )
        {
            _shipDetailCounter = shipDetailCounter;
            _shipDetailsCollectedPopup = shipDetailsCollectedPopup;
            _levelCompletePopup = levelCompletePopup;
            _teleport = teleport;
            _levelsManager = levelsManager;
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
            _levelsManager.CompleteLevel();
            _levelCompletePopup.Show();
        }
    }
}