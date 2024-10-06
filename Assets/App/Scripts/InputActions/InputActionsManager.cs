using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Scripts.InputActions
{
    public class InputActionsManager: IDisposable
    {
        private readonly InputAction _actionRun;
        private readonly InputAction _actionJump;
        private readonly InputAction _actionShoot;

        public event Action<Vector2> OnInputtedRun; 
        public event Action OnInputtedJump;
        public event Action OnInputtedShoot;

        public InputActionsManager(PlayerInput playerInput)
        {
            _actionRun = playerInput.actions["Run"];
            _actionJump = playerInput.actions["Jump"];
            _actionShoot = playerInput.actions["Shoot"];
            
            _actionRun.performed += Run;
            _actionRun.canceled += Run;
            _actionJump.performed += Jump;
            _actionShoot.performed += Shoot;
        }

        private void Shoot(InputAction.CallbackContext obj)
        {
            OnInputtedShoot?.Invoke();
        }

        private void Run(InputAction.CallbackContext obj)
        {
            OnInputtedRun?.Invoke(obj.ReadValue<Vector2>());
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            OnInputtedJump?.Invoke();
        }

        public void Dispose()
        {
            _actionRun.performed -= Run;
            _actionRun.canceled -= Run;
            _actionJump.performed -= Jump;
            _actionShoot.performed -= Shoot;
        }
    }
}
