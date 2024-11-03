using System;
using UnityEngine;

namespace App.Scripts.Players
{
    public interface IPlayerMovement
    {
        public event Action OnJumpedEvent;
        public event Action OnLandingEvent;
        public bool IsGrounded { get; }
        public bool IsMoving { get; }
        public Vector2 MoveInput { get; }
    }
}