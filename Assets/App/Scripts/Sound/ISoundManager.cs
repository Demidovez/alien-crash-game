namespace App.Scripts.Sound
{
    public interface ISoundManager
    {
        public bool IsActiveSounds { get; }
        public bool IsActiveMusic { get; }
        
        public void ToggleSounds();
        public void ToggleMusic();
    }
}