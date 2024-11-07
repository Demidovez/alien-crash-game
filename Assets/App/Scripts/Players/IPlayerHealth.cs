using System;

namespace App.Scripts.Players
{
    public interface IPlayerHealth
    {
        public event Action OnTookDamageEvent;
        public event Action OnDeadEvent;
        public event Action OnAliveEvent;
        
        public bool IsAlive { get; }

        public void TryTakeDamage(float value);
        public void TryRegenerate(float value);
        public void TryAlive();
    }
}