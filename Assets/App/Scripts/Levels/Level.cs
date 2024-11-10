using UnityEngine;

namespace App.Scripts.Levels
{
    public class Level
    {
        public int Id { get; private set; }
        public Sprite Icon { get; private set; }
        public string Name { get; private set; }
        public string Scene { get; private set; }
        public Level Next { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsStarted { get; private set; }
        public bool IsUnlocked { get; private set; }
        public bool IsFirstLevel { get; private set; }
        public bool IsLastLevel { get; private set; }

        public Level(LevelSO levelSo, bool isFirstLevel, bool isLastLevel)
        {
            Id = levelSo.Id;
            Icon = levelSo.Icon;
            Name = levelSo.Name;
            Scene = levelSo.Scene;
            
            IsStarted = false;
            IsFirstLevel = isFirstLevel;
            IsLastLevel = isLastLevel;
        }

        public void SetNext(Level next)
        {
            Next = next;
        }
        
        public void SetCompleteStatus(bool state)
        {
            IsCompleted = state;
        }
        
        public void SetStartStatus(bool state)
        {
            IsStarted = state;
        }
        
        public void SetUnlockStatus(bool state)
        {
            IsUnlocked = state;
        }
    }
}