using System;

namespace App.Scripts.Infrastructure
{
    public interface IGame
    {
        public event Action OnBootedEvent;
        public bool IsGameState { get; }
        public void SetIsGameState(bool isGameState);
        public void Booted();
    }
}