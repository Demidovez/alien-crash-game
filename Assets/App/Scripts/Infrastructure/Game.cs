using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIManager _uiManager;

        public Game(GameStateMachine stateMachine, UIManager uiManager)
        {
            _stateMachine = stateMachine;
            _uiManager = uiManager;
            
            stateMachine.Enter<BootstrapState>();
        }

        public void UpdateHealthUI(float health)
        {
            _uiManager.UpdateHealth(health);
        }
        
        public void UpdateShipDetailsUI(int countCollected, int countAllDetails)
        {
            _uiManager.UpdateShipDetailsCounter(countCollected, countAllDetails);
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