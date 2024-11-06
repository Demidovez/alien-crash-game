using App.Scripts.Infrastructure;
using App.Scripts.Levels;
using UnityEngine;

namespace App.Scripts.UI.Popups.GameWin
{
    public class GameWinPopup : IGameWinPopup
    {
        private readonly IPopupManager _popupManager;
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly ILevelsManager _levelsManager;
        private readonly GameObject _popupBodyPrefab;

        public GameWinPopup(
            IPopupManager popupManager,
            IGameObjectHolder gameObjectHolder,
            ILevelsManager levelsManager,
            GameObject popupBodyPrefab
        )
        {
            _popupManager = popupManager;
            _gameObjectHolder = gameObjectHolder;
            _levelsManager = levelsManager;
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
            
            if (body.TryGetComponent(out GameWinPopupLayout gameWinPopup))
            {
                gameWinPopup.OnFinishClick = () =>
                {
                    popupWrapper.HideImmediately();
                    _levelsManager.ExitLevel();
                };
            }
            
            popupWrapper.Show();
        }
    }
}