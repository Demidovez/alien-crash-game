using UnityEngine;

namespace App.Scripts.Enemy
{
    [RequireComponent(typeof(CharacterController))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _gravityForce = 1f;
        [SerializeField] private float _rotationSpeed = 2f;
        
        private CharacterController _characterController;
        private Vector3 _targetDirection;
        private bool _isGrounded;
        private Transform _target;
        private Vector3 _initPosition;
        
        private Vector3 TargetPosition => _target ? _target.position : _initPosition;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _isGrounded = true;
            _initPosition = transform.position;
            
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }

        private void Update()
        {
            ApplyGravity();
            ApplyRotation();
            ApplyMovement();

            _isGrounded = _characterController.isGrounded;
        }
        
        private void ApplyGravity()
        {
            if (!_isGrounded)
            {
                _characterController.Move(Vector3.up * (_gravity * Time.deltaTime * _gravityForce));
            }
        }
        
        private void ApplyRotation()
        {
            _targetDirection = TargetPosition - transform.position;
            _targetDirection.y = 0;
            _targetDirection.Normalize();
            
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.deltaTime, 0.0f);
            
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        
        private void ApplyMovement()
        {
            _characterController.Move(_targetDirection * (_speed * Time.deltaTime));
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}