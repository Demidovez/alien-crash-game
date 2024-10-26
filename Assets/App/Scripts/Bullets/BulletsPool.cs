using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Bullets
{
    public class BulletsPool: IBulletsPool
    {
        private readonly List<GameObject> _poolObjects;
        private readonly IBulletFactory _bulletFactory;
        private const int InitPoolSize = 10;

        public BulletsPool(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _poolObjects = new List<GameObject>();
        }

        public void FillBy(string bulletPrefabPath)
        {
            _bulletFactory.Load(bulletPrefabPath);
            
            for (int i = 0; i < InitPoolSize; i++)
            {
                CreateObject();
            }
        }

        public Bullet GetBullet()
        {
            foreach (var poolObject in _poolObjects)
            {
                if (!poolObject.activeInHierarchy && poolObject.TryGetComponent(out Bullet bullet))
                {
                    return bullet;
                }
            }

            return CreateObject().GetComponent<Bullet>();
        }
        
        private GameObject CreateObject()
        {
            GameObject bullet = _bulletFactory.Create();
            _poolObjects.Add(bullet);

            return bullet;
        }
    }
}