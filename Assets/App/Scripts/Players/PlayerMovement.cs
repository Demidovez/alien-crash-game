using System;
using App.Scripts.Cameras;
using App.Scripts.InputActions;
using UnityEngine;
using Zenject;

namespace App.Scripts.Players
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        public event Action OnJumpedEvent;
        public event Action OnLandingEvent;
        public bool IsGrounded { get; private set; }
        public bool IsMoving { get; private set; }
        public Vector2 MoveInput { get; private set; }
        
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _gravityForce = 1f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _rotationSpeed = 2f;
        
        private Transform _cameraTransform;
        private CharacterController _characterController;
        private IInputActionsManager _inputActionsManager;
        private IPlayerShooting _playerShooting;
        private Vector3 _movement;
        private float _rotationX;
        private float _rotationY;
        private float _verticalVelocity;

        [Inject]
        public void Construct(
            ICameraController cameraController, 
            IInputActionsManager inputActionsManager,
            IPlayerShooting playerShooting
        )
        {
            _cameraTransform = cameraController.GetCameraTransform();
            _inputActionsManager = inputActionsManager;
            _playerShooting = playerShooting;
        }

        private void Awake()
        {
            IsGrounded = true;
            _characterController = GetComponent<CharacterController>();
            
            _inputActionsManager.OnInputtedRun += SetMoveInput;
            _inputActionsManager.OnInputtedJump += Jump;
            _playerShooting.OnShootEvent += ApplyShootRotation;
        }

        private void FixedUpdate()
        {
            ApplyGravity();
            ApplyRotation();
            ApplyMovement();

            ValidateState();
        }
        
        private void OnDestroy()
        {
            _inputActionsManager.OnInputtedRun -= SetMoveInput;
            _inputActionsManager.OnInputtedJump -= Jump;
            _playerShooting.OnShootEvent -= ApplyShootRotation;
        }

        private void ValidateState()
        {
            IsMoving = _characterController.velocity != Vector3.zero;

            bool newIsGrounded = _characterController.isGrounded;

            if (!IsGrounded && newIsGrounded)
            {
                OnLandingEvent?.Invoke();
            }
            
            IsGrounded = newIsGrounded;
        }
        
        private void SetMoveInput(Vector2 moveInput)
        {
            MoveInput = moveInput;
        }

        private void ApplyGravity()
        {
            if (IsGrounded && _verticalVelocity < 0)
            {
                _verticalVelocity = -1.0f;
            }
            else
            {
                _verticalVelocity += _gravity * Time.fixedDeltaTime;
                _characterController.Move(Vector3.up * (_verticalVelocity * Time.fixedDeltaTime * _gravityForce));
            }
        }

        private void ApplyRotation()
        {
            if (MoveInput == Vector2.zero)
            {
                return;
            }
            
            Quaternion rotation = Quaternion.Euler(0f, _cameraTransform.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.fixedDeltaTime);
        }
        
        private void ApplyShootRotation()
        {
            if (MoveInput != Vector2.zero)
            {
                return;
            }
            
            transform.rotation = Quaternion.Euler(0f, _cameraTransform.eulerAngles.y, 0f);
        }

        private void ApplyMovement()
        {
            _movement = _cameraTransform.right * MoveInput.x + _cameraTransform.forward * MoveInput.y;
            
            if(_movement.magnitude > 1) {
                _movement.Normalize();
            }
            
            _movement.y = -1f;

            float resultSpeed = _speed * (MoveInput.y < 0 ? 0.5f : 1f);
            
            _characterController.Move(_movement * (resultSpeed * Time.fixedDeltaTime));
        }
        
        private void Jump()
        {
            if (IsGrounded)
            {
                OnJumpedEvent?.Invoke();
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * -3 * _gravity);
            }
        }
    }
}
