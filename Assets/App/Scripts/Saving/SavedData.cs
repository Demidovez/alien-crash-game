using App.Scripts.Levels;

namespace App.Scripts.Saving
{
    public class SavedData: ISavedData
    {
        public bool IsActiveSounds { get; private set; }
        public bool IsActiveMusic { get; private set; }
        public Level CurrentLevel { get; private set; }
        

        public void Restore()
        {
            IsActiveSounds = true;
            IsActiveMusic = true;
            CurrentLevel = null;
        }
    }
}