using System;

namespace App.Scripts.Sound
{
    public interface IAudioManager
    {
        public event Action<bool> OnToggleSoundsEvent;
        public event Action<bool> OnToggleMusicEvent;
        
        public bool IsActiveSounds { get; }
        public bool IsActiveMusic { get; }

        public void Init(bool isActiveSounds, bool isActiveMusic);
        public void ToggleSounds();
        public void ToggleMusic();
    }
}