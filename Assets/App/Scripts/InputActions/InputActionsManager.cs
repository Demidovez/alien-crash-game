using System;
using App.Scripts.Infrastructure;
using App.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace App.Scripts.InputActions
{
    public class InputActionsManager: IInputActionsManager, IDisposable
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IGame _game;
        private readonly InputAction _actionRun;
        private readonly InputAction _actionJump;
        private readonly InputAction _actionShoot;
        private readonly InputAction _actionCancelKey;

        public event Action<Vector2> OnInputtedRun; 
        public event Action OnInputtedJump;
        public event Action OnInputtedShoot;
        public event Action OnCancelKeyPressed;

        public InputActionsManager(
            PlayerInput playerInput, 
            ILoadingScreen loadingScreen,
            IGame game
        )
        {
            _loadingScreen = loadingScreen;
            _game = game;

            _actionRun = playerInput.actions["Run"];
            _actionJump = playerInput.actions["Jump"];
            _actionShoot = playerInput.actions["Shoot"];
            _actionCancelKey = playerInput.actions["CancelKey"];
        }

        public void Boot()
        {
            _actionRun.performed += Run;
            _actionRun.canceled += Run;
            _actionJump.performed += Jump;
            _actionShoot.performed += Shoot;
            _actionCancelKey.performed += CancelKeyPressed;
        }

        private void CancelKeyPressed(InputAction.CallbackContext obj)
        {
            if (_loadingScreen.IsActive)
            {
                return;
            }
            
            OnCancelKeyPressed?.Invoke();
        }

        private void Shoot(InputAction.CallbackContext obj)
        {
            if (!_game.IsGameState || Time.timeScale == 0)
            {
                return;
            }
            
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
            _actionCancelKey.performed -= CancelKeyPressed;
        }
    }
}
