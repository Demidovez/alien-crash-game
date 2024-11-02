using App.Scripts.Infrastructure;
using App.Scripts.Levels;
using UnityEngine;

namespace App.Scripts.UI.Popups.LevelComplete
{
    public class LevelCompletePopup : ILevelCompletePopup
    {
        private readonly IPopupManager _popupManager;
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly ILevelsManager _levelsManager;
        private readonly GameObject _popupBodyPrefab;

        public LevelCompletePopup(
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
        
        public void Show(bool isNextLevelLast)
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper(false);
            GameObject body = _gameObjectHolder.InstantiateByPrefab(_popupBodyPrefab, popupWrapper.Body.transform, true);
            
            if (body.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }
            
            if (body.TryGetComponent(out LevelCompletePopupLayout questionPopup))
            {
                if (isNextLevelLast)
                {
                    questionPopup.Text = "Фуух... Успели, вроде жив!\nЭто были последние детали. \n\nОсталось вернуться к кораблю и починить его.\nСтартуем?";
                }
                else
                {
                    questionPopup.Text = "Фуух... Успели, вроде жив!\nТеперь нужно идти искать детали дальше. \n\nДанные новой местности загружены в телепорт.\nСтартуем?";
                }
                
                questionPopup.OnMenuClick = () =>
                {
                    popupWrapper.HideImmediately();
                    _levelsManager.ExitLevel();
                };
                
                questionPopup.OnNextClick = () =>
                {
                    popupWrapper.HideImmediately();
                    _levelsManager.GoToCurrentLevel();
                };
            }
            
            popupWrapper.Show();
        }
    }
}