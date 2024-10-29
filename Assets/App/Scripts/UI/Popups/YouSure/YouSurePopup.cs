﻿using System;
using App.Scripts.Infrastructure;
using UnityEngine;

namespace App.Scripts.UI.Popups.YouSure
{
    public class YouSurePopup: IYouSurePopup
    {
        private readonly IPopupManager _popupManager;
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly GameObject _popupBodyPrefab;

        public YouSurePopup(
            IPopupManager popupManager,
            IGameObjectHolder gameObjectHolder,
            GameObject popupBodyPrefab
        )
        {
            _popupManager = popupManager;
            _gameObjectHolder = gameObjectHolder;
            _popupBodyPrefab = popupBodyPrefab;
        }
        
        public void Show(string text, string okLabel, Action onOkClick, string cancelLabel = null, Action onCancelClick = null)
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper(false);
            GameObject body = _gameObjectHolder.InstantiateByPrefab(_popupBodyPrefab, popupWrapper.Body.transform, true);
            
            if (body.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }

            if (body.TryGetComponent(out SimplePopupContent simplePopupContent))
            {
                simplePopupContent.Title = "Вы уверены?";
                simplePopupContent.Text = text;

                simplePopupContent.OnOkClick = () => popupWrapper.HideImmediately(onOkClick);
                simplePopupContent.OkButtonLabel = okLabel;
                
                simplePopupContent.OnCancelClick = onCancelClick ?? popupWrapper.Hide;
                simplePopupContent.CancelButtonLabel = cancelLabel ?? "Отмена";
            }
            
            popupWrapper.Show();
        }
    }
}