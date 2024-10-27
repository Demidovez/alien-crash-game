namespace App.Scripts.UI.Popups
{
    public interface IPopupManager
    {
        public PopupWrapper CreatePopupWrapper();
        public bool IsActive { get; }
    }
}