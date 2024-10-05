using System;
using App.Scripts.Bullets;
using App.Scripts.Cameras;
using App.Scripts.InputActions;
using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerShooting : IDisposable
    {
        public Action OnShootEvent;
        
        private readonly PlayerHealth _playerHealth;
        private readonly InputActionsManager _inputActionsManager;
        private readonly BulletsPool _bulletsPool;
        private readonly Transform _weaponShootPoint;
        private readonly Transform _weaponAimPoint;

        public PlayerShooting(
            PlayerHealth playerHealth, 
            InputActionsManager inputActionsManager,
            BulletsPool bulletsPool,
            Transform weaponShootPoint,
            CameraController cameraController
        )
        {
            _playerHealth = playerHealth;
            _inputActionsManager = inputActionsManager;
            _bulletsPool = bulletsPool;
            _weaponShootPoint = weaponShootPoint;
            _weaponAimPoint = cameraController.GetCameraTransform();
            
            _inputActionsManager.OnInputtedShoot += Shoot;
        }

        private void Shoot()
        {
            if (!_playerHealth.IsAlive)
            {
                return;
            }
                
            Vector3 shootTargetPosition = GetTargetPosition();

            Bullet bullet = _bulletsPool.GetBullet();
            bullet.MoveFromTo(_weaponShootPoint.position, shootTargetPosition);
                
            OnShootEvent?.Invoke();
        }

        private Vector3 GetTargetPosition()
        {
            Vector3 startRay = _weaponAimPoint.position;
            Vector3 direction = _weaponAimPoint.forward;
            
            if (Physics.Raycast(startRay, direction, out RaycastHit hitInfo, 1000))
            {
                return hitInfo.point;
            }
            
            return _weaponAimPoint.position + _weaponAimPoint.forward * 1000f;
        }

        public void Dispose()
        {
            _inputActionsManager.OnInputtedShoot -= Shoot;
        }
    }
}