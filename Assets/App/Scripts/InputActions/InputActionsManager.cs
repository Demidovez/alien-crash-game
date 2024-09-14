using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Scripts.InputActions
{
    public class InputActionsManager
    {
        private InputAction _actionRun;
        private InputAction _actionJump;

        public event Action<Vector2> OnInputtedRun; 
        public event Action OnInputtedJump;

        public InputActionsManager(PlayerInput playerInput)
        {
            _actionRun = playerInput.actions["Run"];
            _actionJump = playerInput.actions["Jump"];
            
            _actionRun.performed += Run;
            _actionRun.canceled += Run;
            _actionJump.performed += Jump;
        }
        
        private void Run(InputAction.CallbackContext obj)
        {
            OnInputtedRun?.Invoke(obj.ReadValue<Vector2>());
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            OnInputtedJump?.Invoke();
        }

        // TODO: а где отписываться?
        private void OnDisable()
        {
            _actionRun.performed -= Run;
            _actionRun.canceled -= Run;
            _actionJump.performed -= Jump;
        }
    }
}
