using App.Scripts.Levels;

namespace App.Scripts.Saving
{
    public class SavedData: ISavedData
    {
        private readonly ILevelsData _levelsData;
        private readonly ILevelsManager _levelsManager;
        public bool IsActiveSounds { get; private set; }
        public bool IsActiveMusic { get; private set; }

        public SavedData(
            ILevelsData levelsData,
            ILevelsManager levelsManager
        )
        {
            _levelsData = levelsData;
            _levelsManager = levelsManager;
        }

        public void Restore()
        {
            IsActiveSounds = true;
            IsActiveMusic = true;
            
            var level = _levelsData.LastUnlocked ?? _levelsData.Levels[0];
            _levelsManager.SetCurrentLevel(level);
        }
    }
}