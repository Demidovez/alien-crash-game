﻿using App.Scripts.Infrastructure;
using UnityEngine;

namespace App.Scripts.UI.Popups.ShipDetailsCollected
{
    public class ShipDetailsCollectedPopup: IShipDetailsCollectedPopup
    {
        private readonly IPopupManager _popupManager;
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly GameObject _popupBodyPrefab;

        public ShipDetailsCollectedPopup(
            IPopupManager popupManager,
            IGameObjectHolder gameObjectHolder,
            GameObject popupBodyPrefab
        )
        {
            _popupManager = popupManager;
            _gameObjectHolder = gameObjectHolder;
            _popupBodyPrefab = popupBodyPrefab;
        }
        
        public void Show()
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper(false);
            GameObject body = _gameObjectHolder.InstantiateByPrefab(_popupBodyPrefab, popupWrapper.Body.transform, true);
            
            if (body.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }
            
            if (body.TryGetComponent(out ShipDetailsCollectedLayout questionPopup))
            {
                questionPopup.OnOkClick = popupWrapper.Hide;
            }
            
            popupWrapper.Show();
        }
    }
}