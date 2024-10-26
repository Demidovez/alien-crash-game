using System;

namespace App.Scripts.Players
{
    public interface IPlayerHealth
    {
        public event Action OnTookDamageEvent;
        public event Action OnDeadEvent;
        
        public bool IsAlive { get; }

        public void TryTakeDamage(float value);
        public void TryRegenerate(float value);
    }
}