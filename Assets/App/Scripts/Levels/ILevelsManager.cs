namespace App.Scripts.Levels
{
    public interface ILevelsManager
    {
        public Level CurrentLevel { get; }
        public bool CanBackToLevel { get; }
        public bool IsFirstLevel { get; }
        public bool IsLastLevel { get; }
        public void GoToLevel(Level level);
        public void GoToCurrentLevel();
        public void CompleteLevel();
        public void ExitLevel();
        public void SetCurrentLevel(Level level);
    }
}