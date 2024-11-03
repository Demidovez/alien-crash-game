using System;
using App.Scripts.Cameras;
using UnityEngine;

namespace App.Scripts.Sound
{
    public class AudioManager: IAudioManager
    {
        private readonly ICameraController _cameraController;
        private readonly IMusicGame _musicGame;
        public event Action<bool> OnToggleSoundsEvent;
        public event Action<bool> OnToggleMusicEvent;
        public bool IsActiveSounds { get; private set; }
        public bool IsActiveMusic { get; private set; }

        public AudioManager(
            ICameraController cameraController,
            IMusicGame musicGame
        )
        {
            _cameraController = cameraController;
            _musicGame = musicGame;
        }
        
        public void Init(bool isActiveSounds, bool isActiveMusic)
        {
            IsActiveSounds = isActiveSounds;
            IsActiveMusic = isActiveMusic;

            UpdateSoundsState();
        }

        public void ToggleSounds()
        {
            IsActiveSounds = !IsActiveSounds;
            
            OnToggleSoundsEvent?.Invoke(IsActiveSounds);
            
            UpdateSoundsState();
        }
        
        public void ToggleMusic()
        {
            IsActiveMusic = !IsActiveMusic;
            
            OnToggleMusicEvent?.Invoke(IsActiveMusic);
            
            UpdateSoundsState();
        }
        
        private void UpdateSoundsState()
        {
            AudioListener.volume = IsActiveSounds ? 1 : 0;
            
            _musicGame.ActiveMusic(IsActiveSounds && IsActiveMusic);
        }
    }
}