using App.Scripts.Levels;

namespace App.Scripts.Saving
{
    public interface ISavedData
    {
        public bool IsActiveSounds { get; }
        public bool IsActiveMusic { get; }
        public Level CurrentLevel { get; }
        public void Restore();
    }
}