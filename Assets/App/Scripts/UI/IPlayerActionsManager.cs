namespace App.Scripts.UI
{
    public interface IPlayerActionsManager
    {
        public string FixCurrentValue { set; }
        public void SetActivateFixing(bool isActive);
    }
}