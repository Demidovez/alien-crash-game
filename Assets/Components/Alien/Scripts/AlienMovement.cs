using System;
using UnityEngine;

namespace AlienSpace
{
    [RequireComponent(typeof(CharacterController))]
    public class AlienMovement : MonoBehaviour
    {
        public static AlienMovement Instance;
        
        public bool IsGrounded { get; private set; }
        public Vector2 MoveInput { get; set; }
        
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _gravityForce = 1f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _rotationSpeed = 2f;
        [SerializeField] private Transform _cameraTransform;
        
        private CharacterController _characterController;
        private Vector3 _movement;
        private float _rotationX;
        private float _rotationY;
        private float _verticalVelocity;

        private void Awake()
        {
            Instance = this;
            IsGrounded = true;
            
            _characterController = GetComponent<CharacterController>();
        }
        
        private void Update()
        {
            ApplyGravity();
            ApplyRotation();
            ApplyMovement();

            IsGrounded = _characterController.isGrounded;
        }
        
        private void ApplyGravity()
        {
            if (IsGrounded && _verticalVelocity < 0)
            {
                _verticalVelocity = -1.0f;
            }
            else
            {
                _verticalVelocity += _gravity * Time.deltaTime;
                _characterController.Move(Vector3.up * (_verticalVelocity * Time.deltaTime * _gravityForce));
            }
        }
        
        private void ApplyRotation()
        {
            if (MoveInput == Vector2.zero)
            {
                return;
            }
            
            Quaternion rotation = Quaternion.Euler(0f, _cameraTransform.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        } 
        
        private void ApplyMovement()
        {
            _movement = _cameraTransform.right * MoveInput.x + _cameraTransform.forward * MoveInput.y;
            
            if(_movement.magnitude > 1) {
                _movement.Normalize();
            }
            
            _movement.y = -1f;

            float resultSpeed = _speed * (MoveInput.y < 0 ? 0.5f : 1f);
            
            _characterController.Move(_movement * (resultSpeed * Time.deltaTime));
        }
        
        public void Jump()
        {
            if (IsGrounded)
            {
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * -3 * _gravity);
            }
        }
    }
}
