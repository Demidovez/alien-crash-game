using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Bullets
{
    public class BulletsPool
    {
        private readonly BulletFactory _bulletFactory;
        private const int InitPoolSize = 20;
        
        private List<GameObject> _poolObjects;
        
        public BulletsPool(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _bulletFactory.Load();
            
            _poolObjects = new List<GameObject>();

            for (int i = 0; i < InitPoolSize; i++)
            {
                CreateObject();
            }
        }

        private GameObject CreateObject()
        {
            GameObject bullet = _bulletFactory.Create();
            _poolObjects.Add(bullet);

            return bullet;
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
    }
}