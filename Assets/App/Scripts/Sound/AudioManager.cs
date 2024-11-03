using System;

namespace App.Scripts.Sound
{
    public class AudioManager: IAudioManager
    {
        public event Action<bool> OnToggleSoundsEvent;
        public event Action<bool> OnToggleMusicEvent;
        public bool IsActiveSounds { get; private set; }
        public bool IsActiveMusic { get; private set; }
        
        public void Init(bool isActiveSounds, bool isActiveMusic)
        {
            IsActiveSounds = isActiveSounds;
            IsActiveMusic = isActiveMusic;
        }
        
        public void ToggleSounds()
        {
            IsActiveSounds = !IsActiveSounds;
            
            OnToggleSoundsEvent?.Invoke(IsActiveSounds);
        }
        
        public void ToggleMusic()
        {
            IsActiveMusic = !IsActiveMusic;
            
            OnToggleMusicEvent?.Invoke(IsActiveMusic);
        }
    }
}