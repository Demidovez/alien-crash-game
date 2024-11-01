namespace App.Scripts.UI.Popups
{
    public interface IPopupManager
    {
        public PopupWrapper CreatePopupWrapper(bool canClose = true);
        public bool IsActive { get; }
    }
}