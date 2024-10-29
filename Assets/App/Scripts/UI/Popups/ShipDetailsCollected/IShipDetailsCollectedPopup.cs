using System;

namespace App.Scripts.UI.Popups.ShipDetailsCollected
{
    public interface IShipDetailsCollectedPopup
    {
        public void Show(
            string title, 
            string text, 
            string okLabel, 
            Action onOkClick, 
            string cancelLabel = null, 
            Action onCancelClick = null
        );
    }
}