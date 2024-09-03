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
            AlienMovement.Instance.MoveInput = obj.ReadValue<Vector2>();
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            AlienMovement.Instance.Jump();
        }

        private void OnDisable()
        {
            _actionRun.performed -= Run;
            _actionRun.canceled -= Run;
            
            _actionJump.performed -= Jump;
        }
    }
}
