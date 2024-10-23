namespace App.Scripts.Sound
{
    public class SoundManager
    {
        public bool IsActiveSounds { get; private set; }
        public bool IsActiveMusic { get; private set; }

        public SoundManager()
        {
            IsActiveSounds = true;
            IsActiveMusic = true;
        }
        
        public void ToggleSounds()
        {
            IsActiveSounds = !IsActiveSounds;
        }
        
        public void ToggleMusic()
        {
            IsActiveMusic = !IsActiveMusic;
        }
    }
}