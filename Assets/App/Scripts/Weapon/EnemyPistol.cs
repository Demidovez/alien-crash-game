using System.Collections;
using App.Scripts.Bullets;
using UnityEngine;
using Zenject;

namespace App.Scripts.Weapon
{
    public class EnemyPistol : MonoBehaviour, IEnemyPistol
    {
        public Transform ShootPoint;
        public string BulletPrefabPath;
        public GameObject Explosion;
        
        private IBulletsPool _bulletsPool;
        private const float DamageValue = 5f;

        [Inject]
        public void Construct(IBulletsPool bulletsPool)
        {
            _bulletsPool = bulletsPool;
            _bulletsPool.FillBy(BulletPrefabPath);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShootTo(Transform target)
        {
            Explosion.SetActive(true);
            
            Vector3 targetPosition = target.position;
            
            if (target.TryGetComponent(out Collider targetCollider))
            {
                var targetHeight = targetCollider.bounds.size.y;
                targetPosition.y += targetHeight * 0.7f;
            }
            
            Bullet bullet = GetBullet();
            bullet.MoveFromTo(ShootPoint.position, targetPosition);
            
            StartCoroutine(FinishExplosion());
        }

        private IEnumerator FinishExplosion()
        {
            yield return new WaitForSeconds(0.5f);
            Explosion.SetActive(false);
        }
        
        private Bullet GetBullet()
        {
            Bullet bullet = _bulletsPool.GetBullet();
            bullet.SetDamageValue(DamageValue);
            
            return bullet;
        }
    }
}