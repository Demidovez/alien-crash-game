using System;
using App.Scripts.Bullets;
using App.Scripts.Cameras;
using App.Scripts.InputActions;
using UnityEngine;

namespace App.Scripts.Players
{
    public class PlayerShooting : IPlayerShooting, IDisposable
    {
        public event Action OnShootEvent;

        private readonly IPlayer _player;
        private readonly IPlayerHealth _playerHealth;
        private readonly IInputActionsManager _inputActionsManager;
        private readonly IBulletsPool _bulletsPool;
        private readonly Transform _weaponShootPoint;
        private readonly Transform _weaponAimPoint;

        public PlayerShooting(
            IPlayer player, 
            IPlayerHealth playerHealth, 
            IInputActionsManager inputActionsManager,
            IBulletsPool bulletsPool,
            Transform weaponShootPoint,
            ICameraController cameraController
        )
        {
            _player = player;
            _playerHealth = playerHealth;
            _inputActionsManager = inputActionsManager;
            _bulletsPool = bulletsPool;
            _weaponShootPoint = weaponShootPoint;
            _weaponAimPoint = cameraController.GetCameraTransform();
            
            _bulletsPool.FillBy("BulletPlasma");
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
            bullet.MoveFromTo(_player.transform, _weaponShootPoint.position, shootTargetPosition);
                
            OnShootEvent?.Invoke();
        }

        private Vector3 GetTargetPosition()
        {
            Vector3 startRay = _weaponAimPoint.position;
            Vector3 direction = _weaponAimPoint.forward;

            int layerMask = ~(1 << LayerMask.NameToLayer("ShipDetail"));
            
            if (Physics.Raycast(startRay, direction, out RaycastHit hitInfo, 1000, layerMask))
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