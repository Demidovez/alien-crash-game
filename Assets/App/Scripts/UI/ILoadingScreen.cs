namespace App.Scripts.UI
{
    public interface ILoadingScreen
    {
        public bool IsActive { get; }
        public void Show();
        public void Hide();
    }
}