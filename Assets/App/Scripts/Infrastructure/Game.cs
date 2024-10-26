namespace App.Scripts.Infrastructure
{
    public class Game: IGame
    {
        public string CurrentLevelScene { get; private set; }

        public Game()
        {

        }

        public void SetCurrentLevelScene(string name)
        {
            CurrentLevelScene = name;
        }
    }
}