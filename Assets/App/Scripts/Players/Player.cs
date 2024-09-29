using App.Scripts.Camera;
using UnityEngine;
using Zenject;

namespace App.Scripts.Players
{
    public class Player : MonoBehaviour, IDamageable
    {
        private CameraController _cameraController;
        private PlayerHealth _playerHealth;

        [Inject]
        public void Construct(
            CameraController cameraController,
            PlayerHealth playerHealth
        )
        {
            _cameraController = cameraController;
            _playerHealth = playerHealth;
        }
        
        private void Awake()
        {
            Transform cameraPivot = transform.GetChild(0).transform;
            _cameraController.SetTarget(cameraPivot);
        }

        public void Damage(float damage)
        {
            _playerHealth.TryTakeDamage(damage);
        }
    }
}
