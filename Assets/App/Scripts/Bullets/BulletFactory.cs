using UnityEngine;
using Zenject;

namespace App.Scripts.Bullets
{
    public class BulletFactory
    {
        private readonly DiContainer _diContainer;
        private Transform _bulletsContainer;
        private Object _bulletPrefab;

        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load(string bulletPrefabPath)
        {
            _bulletsContainer = new GameObject("Bullets").transform;
            _bulletPrefab = Resources.Load(bulletPrefabPath);
        }
        
        public GameObject Create()
        {
            GameObject bullet = _diContainer.InstantiatePrefab(
                _bulletPrefab, 
                _bulletsContainer.transform.position, 
                Quaternion.identity, 
                _bulletsContainer
            );
            
            bullet.SetActive(false);

            return bullet;
        }
    }
}