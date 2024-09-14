namespace App.Scripts.Infrastructure
{
    public class Game
    {
        public Game(GameStateMachine stateMachine)
        {
            stateMachine.Enter<BootstrapState>();
        }
    }
}