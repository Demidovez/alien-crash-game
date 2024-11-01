using App.Scripts.Infrastructure.GameStateMachines;
using App.Scripts.Infrastructure.GameStateMachines.States;
using App.Scripts.Saving;
using UnityEngine;

namespace App.Scripts.Levels
{
    public class LevelsManager: ILevelsManager
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILevelsData _levelsData;
        private readonly ISavedData _savedData;

        public Level CurrentLevel { get; private set; }

        public LevelsManager(
            IGameStateMachine gameStateMachine,
            ILevelsData levelsData,
            ISavedData savedData
        )
        {
            _gameStateMachine = gameStateMachine;
            _levelsData = levelsData;
            _savedData = savedData;
        }

        public void SetCurrentLevel(Level level)
        {
            CurrentLevel = level;
        }

        public void GoToNextLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, Level>(CurrentLevel.Next);
        }
        
        public void GoToLevel(Level level)
        {
            _gameStateMachine.Enter<LoadLevelState, Level>(level);
        }

        public void GoToCurrentLevel()
        {
            var level = CurrentLevel ?? _savedData.CurrentLevel ?? _levelsData.Levels[0];
            
            GoToLevel(level);
        }
    }
}