using System;

namespace App.Scripts.Infrastructure
{
    public interface IGame
    {
        public event Action OnBootedEvent;
        public string CurrentLevelScene { get; }
        public bool IsGameState { get; }
        public void SetCurrentLevelScene(string name);
        public void SetIsGameState(bool isGameState);
        public void Booted();
    }
}