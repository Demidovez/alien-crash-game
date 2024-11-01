using System;
using App.Scripts.Infrastructure;
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
        private readonly IGame _game;

        public LevelController(
            IShipDetailCounter shipDetailCounter,
            IShipDetailsCollectedPopup shipDetailsCollectedPopup,
            ILevelCompletePopup levelCompletePopup,
            ITeleport teleport,
            IGame game
        )
        {
            _shipDetailCounter = shipDetailCounter;
            _shipDetailsCollectedPopup = shipDetailsCollectedPopup;
            _levelCompletePopup = levelCompletePopup;
            _teleport = teleport;
            _game = game;
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
            _game.LevelComplete();
            _levelCompletePopup.Show();
        }
    }
}