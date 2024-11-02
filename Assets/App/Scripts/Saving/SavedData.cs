using System;
using App.Scripts.Levels;
using App.Scripts.Sound;
using UnityEngine;

namespace App.Scripts.Saving
{
    public class SavedData: ISavedData, IDisposable
    {
        private const string MusicKey = "music";
        private const string SoundsKey = "sounds";
        private const string ActiveStatus = "active";
        private const string InactiveStatus = "inactive";

        private readonly ILevelsData _levelsData;
        private readonly ILevelsManager _levelsManager;
        private readonly ISoundManager _soundManager;

        public SavedData(
            ILevelsData levelsData,
            ILevelsManager levelsManager,
            ISoundManager soundManager
        )
        {
            _levelsData = levelsData;
            _levelsManager = levelsManager;
            _soundManager = soundManager;

            _soundManager.OnToggleSoundsEvent += SaveSoundsState;
            _soundManager.OnToggleMusicEvent += SaveMusicState;
        }
        
        public void Dispose()
        {
            _soundManager.OnToggleSoundsEvent -= SaveSoundsState;
            _soundManager.OnToggleMusicEvent -= SaveMusicState;
        }

        public void Restore()
        {
            RestoreAudioState();
            RestoreCurrentLevel();
        }

        private void RestoreCurrentLevel()
        {
            var level = _levelsData.LastUnlocked ?? _levelsData.Levels[0];
            _levelsManager.SetCurrentLevel(level);
        }

        private void RestoreAudioState()
        {
            bool isActiveSounds = true;
            bool isActiveMusic = true;

            if (PlayerPrefs.HasKey(SoundsKey))
            {
                isActiveSounds = PlayerPrefs.GetString(SoundsKey) == ActiveStatus;
            }
            
            if (PlayerPrefs.HasKey(MusicKey))
            {
                isActiveMusic = PlayerPrefs.GetString(MusicKey) == ActiveStatus;
            }

            _soundManager.Init(isActiveSounds, isActiveMusic);
        }

        private void SaveSoundsState(bool isActive)
        {
            PlayerPrefs.SetString(SoundsKey, isActive ? ActiveStatus : InactiveStatus);
            PlayerPrefs.Save();
        }

        private void SaveMusicState(bool isActive)
        {
            PlayerPrefs.SetString(MusicKey, isActive ? ActiveStatus : InactiveStatus);
            PlayerPrefs.Save();
        }
    }
}