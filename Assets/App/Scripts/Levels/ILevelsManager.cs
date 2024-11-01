namespace App.Scripts.Levels
{
    public interface ILevelsManager
    {
        public Level CurrentLevel { get; }
        public void GoToLevel(Level level);
        public void SetCurrentLevel(Level level);
        public void GoToNextLevel();
        public void GoToCurrentLevel();
    }
}