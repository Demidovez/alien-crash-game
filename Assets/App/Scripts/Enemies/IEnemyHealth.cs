using System;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public interface IEnemyHealth
    {
        public event Action<Transform> OnTookDamageEvent;
        public event Action OnConcussionEvent;
        public event Action OnOutFromConcussionEvent;
        
        public bool IsConcussion { get; }

        public void TryTakeDamage(float value, Transform attacker);
    }
}