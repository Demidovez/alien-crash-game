using System.Collections;
using App.Scripts.Bullets;
using UnityEngine;
using Zenject;

namespace App.Scripts.Weapon
{
    public class EnemyPistol : MonoBehaviour
    {
        public Transform ShootPoint;
        public string BulletPrefabPath;
        public GameObject Explosion;
        
        private BulletsPool _bulletsPool;

        [Inject]
        public void Construct(BulletsPool bulletsPool)
        {
            _bulletsPool = bulletsPool;
            _bulletsPool.FillBy(BulletPrefabPath);
        }

        public Bullet GetBullet()
        {
            return _bulletsPool.GetBullet();
        }

        public void Shoot()
        {
            Explosion.SetActive(true);
            StartCoroutine(FinishExplosion());
        }

        private IEnumerator FinishExplosion()
        {
            yield return new WaitForSeconds(0.5f);
            Explosion.SetActive(false);
        }
    }
}