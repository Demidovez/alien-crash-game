﻿using App.Scripts.Infrastructure.GameStateMachines;
using App.Scripts.Infrastructure.GameStateMachines.States;

namespace App.Scripts.Levels
{
    public class LevelsManager: ILevelsManager
    {
        private readonly IGameStateMachine _gameStateMachine;

        public Level CurrentLevel { get; private set; }
        public bool CanBackToLevel => CurrentLevel?.IsStarted ?? false;
        public bool IsFirstLevel => CurrentLevel?.IsFirstLevel ?? false;
        public bool IsLastLevel => CurrentLevel?.IsLastLevel ?? false;

        public LevelsManager(
            IGameStateMachine gameStateMachine
        )
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void GoToLevel(Level level)
        {
            SetCurrentLevel(level);
            
            if (level.IsUnlocked)
            {
                _gameStateMachine.Enter<LoadLevelState, Level>(level);
            }
        }

        public void GoToCurrentLevel()
        {
            if (CurrentLevel != null)
            {
                CurrentLevel.SetStartStatus(true);
                _gameStateMachine.Enter<LoadLevelState, Level>(CurrentLevel);
            }
        }
        
        public void CompleteLevel()
        {
            CurrentLevel?.SetCompleteStatus(true);
            CurrentLevel?.SetStartStatus(false);
            CurrentLevel?.Next?.SetUnlockStatus(true);
            
            SetCurrentLevel(CurrentLevel?.Next);
        }

        public void ExitLevel()
        {
            CurrentLevel?.SetStartStatus(false);
            _gameStateMachine.Enter<MenuState>();
        }
        
        public void SetCurrentLevel(Level level)
        {
            CurrentLevel?.SetStartStatus(false);
            
            CurrentLevel = level;
        }
    }
}