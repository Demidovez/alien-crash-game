using App.Scripts.UI;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerInterfaceManager _playerInterfaceManager;

        public Game(GameStateMachine stateMachine, PlayerInterfaceManager playerInterfaceManager)
        {
            _stateMachine = stateMachine;
            _playerInterfaceManager = playerInterfaceManager;
            
            stateMachine.Enter<BootstrapState>();
        }

        public void UpdateHealthUI(float health)
        {
            _playerInterfaceManager.UpdateHealth(health);
        }
        
        public void UpdateShipDetailsUI(int countCollected, int countAllDetails)
        {
            _playerInterfaceManager.UpdateShipDetailsCounter(countCollected, countAllDetails);
        }

        public void ToNextLevel(string nextScene)
        {
            _stateMachine.Enter<LoadLevelState, string>(nextScene);
        }
        
        public void RestartLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
        }
    }
}