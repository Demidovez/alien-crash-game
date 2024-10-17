using App.Scripts.Bullets;
using UnityEngine;

namespace App.Scripts.Weapon
{
    public class EnemySpray : MonoBehaviour
    {
        public Transform SprayPoint;
        
        private BulletsPool _bulletsPool;
        private const float DamageValue = 5f;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void SprayTo(Transform target)
        {
            Vector3 targetPosition = target.position;
            
            if (target.TryGetComponent(out Collider targetCollider))
            {
                float targetHeight = targetCollider.bounds.size.y;
                targetPosition.y += targetHeight * 0.7f;
            }
            
            Debug.Log("Spray");
            
            // Bullet bullet = _enemyPistol.GetBullet();
            // bullet.MoveFromTo(_enemyPistol.ShootPoint.position, targetPosition);
            
            // Collider[] targetInRadius = Physics.OverlapSphere(transform.position, ViewRadius, _visibleMask);
            //
            // for (int i = 0; i < targetInRadius.Length; i++)
            // {
            //     Transform target = targetInRadius[i].transform;
            //     
            //     bool isTarget = Helper.ContainsLayer(target.gameObject.layer, _targetMask);
            //     
            //     if (isTarget && IsCurrentVisibleInAngleArea(target))
            //     {
            //         OnAddedVisibleTarget?.Invoke(target);
            //         VisibleTarget = target;
            //         return;
            //     }
            // }
            //
            // if (other.TryGetComponent(out IDamageable damageable))
            // {
            //     damageable.Damage(_damageValue);
            // }
        }
    }
}