using App.Scripts.Infrastructure.GameStateMachines;
using App.Scripts.Infrastructure.GameStateMachines.States;

namespace App.Scripts.Infrastructure
{
    public class LevelSwitch: ILevelSwitch
    {
        private readonly IGameStateMachine _gameStateMachine;

        public LevelSwitch(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void GoToLevel(string level)
        {
            _gameStateMachine.Enter<LoadLevelState, string>(level);
        }
    }
}