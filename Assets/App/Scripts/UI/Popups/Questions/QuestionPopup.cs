using System;
using App.Scripts.Infrastructure;
using UnityEngine;

namespace App.Scripts.UI.Popups.Questions
{
    public class QuestionPopup : IQuestionPopup
    {
        private readonly IPopupManager _popupManager;
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly GameObject _popupBodyPrefab;

        public QuestionPopup(
            IPopupManager popupManager,
            IGameObjectHolder gameObjectHolder,
            GameObject popupBodyPrefab
        )
        {
            _popupManager = popupManager;
            _gameObjectHolder = gameObjectHolder;
            _popupBodyPrefab = popupBodyPrefab;
        }
        
        public void Show(string title, string text, string okLabel, Action onOkClick, string cancelLabel = null, Action onCancelClick = null)
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper(false);
            GameObject body = _gameObjectHolder.InstantiateByPrefab(_popupBodyPrefab, popupWrapper.Body.transform, true);
            
            if (body.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }

            if (body.TryGetComponent(out QuestionPopupLayout questionPopup))
            {
                questionPopup.Title = title;
                questionPopup.Text = text;

                questionPopup.OnOkClick = () => popupWrapper.HideImmediately(onOkClick);
                questionPopup.OkButtonLabel = okLabel;
                
                questionPopup.OnCancelClick = onCancelClick ?? popupWrapper.Hide;
                questionPopup.CancelButtonLabel = cancelLabel ?? "Отмена";
            }
            
            popupWrapper.Show();
        }
    }
}