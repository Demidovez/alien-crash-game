namespace App.Scripts.Infrastructure.GameStateMachines
{
    public interface IGameStateFactory
    {
        public TState Create<TState>() where TState : class, IExitableState;
    }
}