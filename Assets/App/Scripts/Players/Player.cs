using App.Scripts.Cameras;
using App.Scripts.Common;
using App.Scripts.Levels;
using App.Scripts.ShipDetail;
using UnityEngine;
using Zenject;

namespace App.Scripts.Players
{
    public class Player : MonoBehaviour, IPlayer, IHealthRegenerable, IShipDetailCollector, IDamageable
    {
        private ICameraController _cameraController;
        private IPlayerHealth _playerHealth;
        private IShipDetailCounter _shipDetailCounter;
        private ILevelsManager _levelsManager;

        [Inject]
        public void Construct(
            ICameraController cameraController,
            IPlayerHealth playerHealth,
            IShipDetailCounter shipDetailCounter,
            ILevelsManager levelsManager
        )
        {
            _cameraController = cameraController;
            _playerHealth = playerHealth;
            _shipDetailCounter = shipDetailCounter;
            _levelsManager = levelsManager;
        }
        
        private void Awake()
        {
            Transform cameraPivot = transform.GetChild(0).transform;
            _cameraController.SetTarget(cameraPivot);
        }

        private void Start()
        {
            if (_levelsManager.IsFirstLevel)
            {
                _playerHealth.TryAlive();
            }
        }

        public void Damage(float damage)
        {
            _playerHealth.TryTakeDamage(damage);
        }
        
        public void HealthRegenerate(float value)
        {
            _playerHealth.TryRegenerate(value);
        }
        
        public void ShipDetailCollect()
        {
            _shipDetailCounter.CollectedDetail();
        }
    }
}
