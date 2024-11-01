using System;

namespace App.Scripts.UI.Popups.Questions
{
    public interface IQuestionPopup
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