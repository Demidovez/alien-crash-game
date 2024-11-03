using App.Scripts.Bullets;
using App.Scripts.Cameras;
using App.Scripts.Players;
using UnityEngine;
using Zenject;

namespace App.Scripts.Weapon
{
    public class PlayerBlaster: MonoBehaviour, IPlayerBlaster
    {
        public AudioSource AudioSource;
        public Transform ShootPoint;
        
        private IBulletsPool _bulletsPool;
        private IPlayer _player;
        private Transform _weaponAimPoint;
        private const float DamageValue = 5f;

        [Inject]
        public void Construct(
            IBulletsPool bulletsPool,
            IPlayer player,
            ICameraController cameraController
        )
        {
            _player = player;
            _bulletsPool = bulletsPool;
            _bulletsPool.FillBy("BulletPlasma");
            
            _weaponAimPoint = cameraController.GetCameraTransform();
        }

        public void Shoot()
        {
            Vector3 shootTargetPosition = GetTargetPosition();
            
            Bullet bullet = GetBullet();
            
            bullet.MoveFromTo(_player.transform, ShootPoint.position, shootTargetPosition);
            
            AudioSource.Play();
        }
        
        private Bullet GetBullet()
        {
            Bullet bullet = _bulletsPool.GetBullet();
            bullet.SetDamageValue(DamageValue);
            
            return bullet;
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
    }
}