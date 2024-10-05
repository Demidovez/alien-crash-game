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

        public void UpdateHealthBar(float health)
        {
            _uiManager.UpdateHealth(health);
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