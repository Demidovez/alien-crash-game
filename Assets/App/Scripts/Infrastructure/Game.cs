namespace App.Scripts.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;

        public Game(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            stateMachine.Enter<BootstrapState>();
        }

        public void ToNextLevel(string nextScene)
        {
            _stateMachine.Enter<LoadLevelState, string>(nextScene);
        }
    }
}