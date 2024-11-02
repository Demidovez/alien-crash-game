using System;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class Game: IGame
    {
        public event Action OnBootedEvent; 
        
        public bool IsGameState { get; private set; }
        
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