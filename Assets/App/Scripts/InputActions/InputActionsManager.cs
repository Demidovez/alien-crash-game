using System;
using AlienSpace;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputActionsSpace
{
    public class InputActionsManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        
        private InputAction _actionRun;
        private InputAction _actionJump;

        public event Action<Vector2> OnInputtedRun; 
        public event Action OnInputtedJump; 
        
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            
            _actionRun = _playerInput.actions["Run"];
            _actionJump = _playerInput.actions["Jump"];
        }
        
        private void OnEnable()
        {
            _actionRun.performed += Run;
            _actionRun.canceled += Run;
            
            _actionJump.performed += Jump;
        }
        
        private void Run(InputAction.CallbackContext obj)
        {
            OnInputtedRun?.Invoke(obj.ReadValue<Vector2>());
            // AlienMovement.Instance.MoveInput = ;
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            OnInputtedJump?.Invoke();
            // AlienMovement.Instance.Jump();
        }

        private void OnDisable()
        {
            _actionRun.performed -= Run;
            _actionRun.canceled -= Run;
            
            _actionJump.performed -= Jump;
        }
    }
}
