namespace App.Scripts.UI
{
    public interface IPopupManager
    {
        public void ShowCompleteCollectDetails();
        public void HideCompleteCollectDetails();
        public void ShowGameOver();
        public void HideGameOver();
        
        public bool IsActive { get; }
    }
}