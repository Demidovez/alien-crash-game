using UnityEngine;

namespace App.Scripts.Enemies
{
    public interface IEnemyChaseManager
    {
        public bool IsChasing { get; }
        public Transform Target { get; }

        public bool IsFocusedOnTarget();
    }
}