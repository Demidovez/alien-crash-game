using UnityEngine;

namespace App.Scripts.Players
{
    public interface IPlayerMovement
    {
        public bool IsGrounded { get; }
        public bool IsMoving { get; }
        public Vector2 MoveInput { get; }
    }
}