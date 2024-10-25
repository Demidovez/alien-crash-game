using System;
using App.Scripts.Infrastructure.GameStateMachines;
using App.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure
{
    public class Game
    {
        // public event Action OnStartedGame;
        private readonly PlayerInterfaceManager _playerInterfaceManager;
        
        public string CurrentLevelScene { get; private set; }

        public Game(PlayerInterfaceManager playerInterfaceManager)
        {
            _playerInterfaceManager = playerInterfaceManager;
            
            // _stateMachine.Enter<BootstrapState>();
        }

        public void SetCurrentLevelScene(string name)
        {
            CurrentLevelScene = name;
        }
        
        public void UpdateHealthUI(float health)
        {
            _playerInterfaceManager.UpdateHealth(health);
        }
        
        public void UpdateShipDetailsUI(int countCollected, int countAllDetails)
        {
            _playerInterfaceManager.UpdateShipDetailsCounter(countCollected, countAllDetails);
        }

        
        // TODO: как будто это тут не нужно
        public void ToNextLevel(string nextScene)
        {
            Debug.Log("ToNextLevel");
            // _stateMachine.Enter<LoadLevelState, string>(nextScene);
        }
        
        public void RestartLevel()
        {
            Debug.Log("RestartLevel");
            // _stateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
        }
    }
}