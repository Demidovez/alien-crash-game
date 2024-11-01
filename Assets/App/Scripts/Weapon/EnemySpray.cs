using App.Scripts.Bullets;
using App.Scripts.Common;
using UnityEngine;

namespace App.Scripts.Weapon
{
    public class EnemySpray : MonoBehaviour, IEnemySpray
    {
        public Transform SprayPoint;
        public LayerMask TargetLayerMask;
        
        private BulletsPool _bulletsPool;
        private const float DamageValue = 0.01f;
        private const float SprayDistance = 3.5f;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void SprayTo(Transform target)
        {
            Vector3 direction = ((target.position + Vector3.up) - SprayPoint.position);
                
            if (Physics.Raycast(SprayPoint.position, direction, SprayDistance, TargetLayerMask))
            {
                if (target.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(DamageValue);
                }
            }
        }
    }
}