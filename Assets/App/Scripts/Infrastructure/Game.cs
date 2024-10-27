using System;

namespace App.Scripts.Infrastructure
{
    public class Game: IGame
    {
        public event Action OnBootedEvent; 
        
        public string CurrentLevelScene { get; private set; }

        public void SetCurrentLevelScene(string name)
        {
            CurrentLevelScene = name;
        }

        public void Booted()
        {
            OnBootedEvent?.Invoke();
        }
    }
}