using System;
using App.Scripts.Cameras;
using App.Scripts.Players;
using App.Scripts.ShipDetail;
using App.Scripts.Teleports;
using App.Scripts.UI;
using App.Scripts.UI.Popups.GameWin;
using App.Scripts.UI.Popups.LevelComplete;
using App.Scripts.UI.Popups.ShipDetailsCollected;
using UnityEngine;
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
        private readonly IPlayerInterfaceManager _playerInterfaceManager;
        private readonly ICameraController _cameraController;
        private readonly IGameWinPopup _gameWinPopup;

        private bool _isNextLevelLast;

        public LevelController(
            IShipDetailCounter shipDetailCounter,
            IShipDetailsCollectedPopup shipDetailsCollectedPopup,
            ILevelCompletePopup levelCompletePopup,
            ITeleport teleport,
            ILevelsManager levelsManager,
            IPlayerInterfaceManager playerInterfaceManager,
            ICameraController cameraController,
            IGameWinPopup gameWinPopup
        )
        {
            _shipDetailCounter = shipDetailCounter;
            _shipDetailsCollectedPopup = shipDetailsCollectedPopup;
            _levelCompletePopup = levelCompletePopup;
            _teleport = teleport;
            _levelsManager = levelsManager;
            _playerInterfaceManager = playerInterfaceManager;
            _cameraController = cameraController;
            _gameWinPopup = gameWinPopup;

            _isNextLevelLast = _levelsManager.CurrentLevel?.Next?.IsLastLevel ?? false;
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

        public void WholeGameComplete()
        {
            _gameWinPopup.Show();
        }

        public void WholeGameAlmostComplete()
        {
            _playerInterfaceManager.SetVisible(false);
            _cameraController.DisableCamera();
        }

        private void CollectedDetails()
        {
            _teleport.SetActiveStatus(true);
            
            _shipDetailsCollectedPopup.Show(_isNextLevelLast);
        }
        
        private void EnteredTeleport()
        {
            _levelsManager.CompleteLevel();
            
            _levelCompletePopup.Show(_isNextLevelLast);
        }
    }
}