using System;
using UnityEngine;

namespace App.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform Target;
        public bool IsGrounded { get; private set; }
        
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _gravityForce = 1f;
        [SerializeField] private float _rotationSpeed = 2f;
        
        private CharacterController _characterController;
        private Vector3 _targetDirection;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            IsGrounded = true;
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }

        private void Update()
        {
            if (Target != null)
            {
                ApplyGravity();
                ApplyRotation();
                ApplyMovement(); 
            }

            IsGrounded = _characterController.isGrounded;
        }
        
        private void ApplyGravity()
        {
            if (!IsGrounded)
            {
                _characterController.Move(Vector3.up * (_gravity * Time.deltaTime * _gravityForce));
            }
        }
        
        private void ApplyRotation()
        {
            _targetDirection = Target.position - transform.position;
            _targetDirection.y = 0;
            _targetDirection.Normalize();
            
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.deltaTime, 0.0f);
            
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        
        private void ApplyMovement()
        {
            if (transform.position == Target.position)
            {
                return;
            }
            
            _characterController.Move(_targetDirection * (_speed * Time.deltaTime));
        }

        // TODO: временно 
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Target = other.transform;
            }
        }

        public void SetTargetPosition(Vector3 position)
        {
            // _characterController.Move()
        }
    }
}