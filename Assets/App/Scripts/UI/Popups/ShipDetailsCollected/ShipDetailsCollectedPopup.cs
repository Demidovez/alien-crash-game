using App.Scripts.Infrastructure;
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
        
        public void Show(bool isNextLevelLast)
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper(false);
            GameObject body = _gameObjectHolder.InstantiateByPrefab(_popupBodyPrefab, popupWrapper.Body.transform, true);
            
            if (body.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }
            
            if (body.TryGetComponent(out ShipDetailsCollectedLayout questionPopup))
            {
                if (isNextLevelLast)
                {
                    questionPopup.Text =
                        "Круто, ты собрал все нужные детали корабля. Но это еще не все — нужно их доставить обратно.\n\nИди обратно к телепорту, и мы перенесем тебя к кораблю.\nТак держать!";
                }
                else
                {
                    questionPopup.Text =
                        "Круто, ты собрал нужные детали корабля. Но это еще не все — есть еще потерянные части.\n\nИди обратно к телепорту, и мы перенесем тебя на следующее место.\nТак держать!";
                }
                
                questionPopup.OnOkClick = popupWrapper.Hide;
            }
            
            popupWrapper.Show();
        }
    }
}