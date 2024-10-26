namespace App.Scripts.Infrastructure
{
    public interface IGame
    {
        public string CurrentLevelScene { get; }
        public void SetCurrentLevelScene(string name);
    }
}