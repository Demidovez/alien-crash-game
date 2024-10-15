using App.Scripts.Common;
using UnityEngine;

namespace App.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        private const float Speed = 50f;
        private const float LifeTime = 5f;
        private const float DamageValue = 30f;

        private Transform _attacker;
        private Vector3 _direction;
        private bool _isMoving;
        private float _time;

        private void LateUpdate()
        {
            if (!_isMoving)
            {
                return;    
            }

            if (_time >= LifeTime)
            {
                CompleteMove();
                return;
            }
            
            transform.position += _direction * (Speed * Time.deltaTime);
            _time += Time.deltaTime;
        }
        
        public void MoveFromTo(Vector3 from, Vector3 to)
        {
            MoveFromTo(null, from, to);
        }

        public void MoveFromTo(Transform attacker, Vector3 from, Vector3 to)
        {
            _attacker = attacker;
            _direction = (to - from).normalized;

            transform.position = from;
            transform.rotation = Quaternion.LookRotation(to - from);
            
            _isMoving = true;
            gameObject.SetActive(true);
        }
        
        private void CompleteMove()
        {
            _isMoving = false;
            _time = 0;
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("ShipDetail"))
            {
                return;
            }
            
            CompleteMove();
            
            if (other.TryGetComponent(out IDamageableWithAttacker damageableWithAttacker))
            {
                damageableWithAttacker.Damage(DamageValue, _attacker);
                return;
            } 
            
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(DamageValue);
            }
        }
    }
}