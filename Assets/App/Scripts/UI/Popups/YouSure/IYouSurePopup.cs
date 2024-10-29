using System;

namespace App.Scripts.UI.Popups.YouSure
{
    public interface IYouSurePopup
    {
        public void Show(string text, string okLabel, Action onOkClick, string cancelLabel = null, Action onCancelClick = null);
    }
}