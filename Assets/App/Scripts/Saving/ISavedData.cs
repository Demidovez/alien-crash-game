namespace App.Scripts.Saving
{
    public interface ISavedData
    {
        public bool IsActiveSounds { get; }
        public bool IsActiveMusic { get; }
        public void Restore();
    }
}