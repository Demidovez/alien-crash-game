namespace App.Scripts.UI
{
    public interface IPlayerInterfaceManager
    {
        public void SetVisible(bool isVisible);
        public void UpdateHealth(float value);
        public void UpdateShipDetailsCounter(int countCollected, int countAllDetails);
    }
}