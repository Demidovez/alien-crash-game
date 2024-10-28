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
        
        public void Show(string text)
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper(false);
            GameObject body = _gameObjectHolder.InstantiateByPrefab(_popupBodyPrefab, popupWrapper.Body.transform, true);
            
            if (body.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }

            if (body.TryGetComponent(out SimplePopupContent simplePopupContent))
            {
                simplePopupContent.SetTitle("Вы уверены?");
                simplePopupContent.SetText(text);
            }
            
            popupWrapper.Show();
        }
    }
}