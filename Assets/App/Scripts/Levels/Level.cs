using UnityEngine;

namespace App.Scripts.Levels
{
    public class Level
    {
        public Sprite Icon { get; private set; }
        public string Name { get; private set; }
        public Object Scene { get; private set; }
        public Level Next { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsStarted { get; private set; }
        public bool IsUnlocked { get; private set; }
        public bool IsFirstLevel { get; private set; }
        public bool IsLastLevel { get; private set; }

        private LevelSO _levelSo;

        public Level(LevelSO levelSo, bool isFirstLevel, bool isLastLevel)
        {
            _levelSo = levelSo;
            
            Icon = levelSo.Icon;
            Name = levelSo.Name;
            Scene = levelSo.Scene;

            IsCompleted = levelSo.IsCompleted;
            IsStarted = false;
            IsUnlocked = levelSo.IsUnlocked;
            IsFirstLevel = isFirstLevel;
            IsLastLevel = isLastLevel;
        }

        public void SetNext(Level next)
        {
            Next = next;
        }
        
        public void SetCompleteStatus(bool state)
        {
            _levelSo.IsCompleted = state;
            IsCompleted = state;
        }
        
        public void SetStartStatus(bool state)
        {
            IsStarted = state;
        }
        
        public void SetUnlockStatus(bool state)
        {
            _levelSo.IsUnlocked = state;
            IsUnlocked = state;
        }
    }
}