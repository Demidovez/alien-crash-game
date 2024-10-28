using System;

namespace App.Scripts.Infrastructure
{
    public class Game: IGame
    {
        public event Action OnBootedEvent; 
        
        public string CurrentLevelScene { get; private set; }
        public bool IsGameState { get; private set; }

        public void SetCurrentLevelScene(string name)
        {
            CurrentLevelScene = name;
        }
        
        public void SetIsGameState(bool isGameState)
        {
            IsGameState = isGameState;
        }

        public void Booted()
        {
            OnBootedEvent?.Invoke();
        }
    }
}