using System;
using UnityEngine;

namespace App.Scripts.InputActions
{
    public interface IInputActionsManager
    {
        public event Action<Vector2> OnInputtedRun; 
        public event Action OnInputtedJump;
        public event Action OnInputtedShoot;
        public event Action OnToggleMenu;

        public void Boot();
    }
}