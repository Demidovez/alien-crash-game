using System;
using App.Scripts.Levels;
using App.Scripts.Sound;
using UnityEngine;

namespace App.Scripts.Saving
{
    public class SavedData: ISavedData, IDisposable
    {
        private const string LevelIdKey = "level_id";
        private const string MusicKey = "music";
        private const string SoundsKey = "sounds";
        private const string ActiveStatus = "active";
        private const string InactiveStatus = "inactive";

        private readonly ILevelsData _levelsData;
        private readonly ILevelsManager _levelsManager;
        private readonly IAudioManager _audioManager;

        public SavedData(
            ILevelsData levelsData,
            ILevelsManager levelsManager,
            IAudioManager audioManager
        )
        {
            _levelsData = levelsData;
            _levelsManager = levelsManager;
            _audioManager = audioManager;

            _audioManager.OnToggleSoundsEvent += SaveAudiosState;
            _audioManager.OnToggleMusicEvent += SaveMusicState;
            _levelsManager.OnUnlockedLevelEvent += SaveUnlockedLevelId;
        }
        
        public void Dispose()
        {
            _audioManager.OnToggleSoundsEvent -= SaveAudiosState;
            _audioManager.OnToggleMusicEvent -= SaveMusicState;
            _levelsManager.OnUnlockedLevelEvent -= SaveUnlockedLevelId;
        }

        public void Restore()
        {
            RestoreAudioState();
            RestoreCurrentLevel();
        }

        private void RestoreCurrentLevel()
        {
            var levelId = 0;

            if (PlayerPrefs.HasKey(LevelIdKey))
            {
                levelId = PlayerPrefs.GetInt(LevelIdKey);
            }

            Level currentLevel = null;
            
            foreach (var level in _levelsData.Levels)
            {
                if (level.Id == levelId)
                {
                    currentLevel = level;
                }

                if (level.Id <= levelId)
                {
                    level.SetUnlockStatus(true);
                }
            }

            if (currentLevel != null)
            {
                _levelsManager.SetCurrentLevel(currentLevel);
            }
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

            _audioManager.Init(isActiveSounds, isActiveMusic);
        }

        private void SaveAudiosState(bool isActive)
        {
            PlayerPrefs.SetString(SoundsKey, isActive ? ActiveStatus : InactiveStatus);
            PlayerPrefs.Save();
        }

        private void SaveMusicState(bool isActive)
        {
            PlayerPrefs.SetString(MusicKey, isActive ? ActiveStatus : InactiveStatus);
            PlayerPrefs.Save();
        }
        
        private void SaveUnlockedLevelId(int id)
        {
            var currentLevelId = 0;
            
            if (PlayerPrefs.HasKey(LevelIdKey))
            {
                currentLevelId = PlayerPrefs.GetInt(LevelIdKey);
            }

            if (currentLevelId < id)
            {
                PlayerPrefs.SetInt(LevelIdKey, id);
                PlayerPrefs.Save();
            }
        }
    }
}