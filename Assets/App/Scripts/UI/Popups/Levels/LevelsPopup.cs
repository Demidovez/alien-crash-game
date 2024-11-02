using System.Collections.Generic;
using App.Scripts.Infrastructure;
using App.Scripts.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Popups.Levels
{
    public class LevelsPopup: ILevelsPopup
    {
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly ILevelsManager _levelsManager;
        private readonly IPopupManager _popupManager;
        private readonly ILevelsData _levelsData;
        private readonly GameObject _popupLevelsPrefab;
        private readonly GameObject _levelCardPrefab;

        private PopupWrapper _popupWrapper;

        public LevelsPopup(
            IGameObjectHolder gameObjectHolder, 
            ILevelsManager levelsManager, 
            IPopupManager popupManager,
            ILevelsData levelsData,
            GameObject popupLevelsPrefab,
            GameObject levelCardPrefab
        )
        {
            _gameObjectHolder = gameObjectHolder;
            _levelsManager = levelsManager;
            _popupManager = popupManager;
            _levelsData = levelsData;
            _popupLevelsPrefab = popupLevelsPrefab;
            _levelCardPrefab = levelCardPrefab;
        }
        
        public void Show()
        {
            PopupWrapper popupWrapper = _popupManager.CreatePopupWrapper();
            GameObject levelsBody = _gameObjectHolder.InstantiateByPrefab(_popupLevelsPrefab, popupWrapper.Body.transform, true);
            GridLayoutGroup gridLayout = levelsBody.GetComponentInChildren<GridLayoutGroup>();

            if (levelsBody.TryGetComponent(out RectTransform rectTransform))
            {
                popupWrapper.SetBodySize(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            }
            
            InitLevelCards(popupWrapper, gridLayout.gameObject, _levelCardPrefab);
            
            popupWrapper.Show();
        }
        
        private void InitLevelCards(PopupWrapper popupWrapper, GameObject parent, GameObject levelCardPrefab)
        {
            foreach (var level in _levelsData.Levels)
            {
                GameObject levelObj = _gameObjectHolder.InstantiateByPrefab(levelCardPrefab, parent.transform);

                if (levelObj.TryGetComponent(out LevelCard card))
                {
                    card.Title.SetText(level.Name);
                    card.Icon.sprite = level.Icon;
                    card.IsUnlocked = level.IsUnlocked;
                    card.OnClick = () =>
                    {
                        popupWrapper.HideImmediately();
                        _levelsManager.GoToLevel(level);
                    };
                }
            }
        }
    }
}