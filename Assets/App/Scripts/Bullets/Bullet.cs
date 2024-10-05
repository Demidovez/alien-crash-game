using UnityEngine;

namespace App.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        private const float Speed = 50f;
        private const float LifeTime = 5f;
        
        private Vector3 _targetPosition;
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
            
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);
            _time += Time.deltaTime;
        }

        public void MoveFromTo(Vector3 from, Vector3 to)
        {
            transform.position = from;
            _targetPosition = to;
            
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
            CompleteMove();
            Debug.Log("Bullet trigger");
        }
    }
}