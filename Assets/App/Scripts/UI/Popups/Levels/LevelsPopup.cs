using System.Collections.Generic;
using App.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Popups.Levels
{
    public class LevelsPopup: ILevelsPopup
    {
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly ILevelSwitch _levelSwitch;
        private readonly IPopupManager _popupManager;
        private readonly List<LevelCardSO> _levelsConfig;
        private readonly GameObject _popupLevelsPrefab;
        private readonly GameObject _levelCardPrefab;

        private PopupWrapper _popupWrapper;

        public LevelsPopup(
            IGameObjectHolder gameObjectHolder, 
            ILevelSwitch levelSwitch, 
            IPopupManager popupManager,
            List<LevelCardSO> levelsConfig, 
            GameObject popupLevelsPrefab,
            GameObject levelCardPrefab
        )
        {
            _gameObjectHolder = gameObjectHolder;
            _levelSwitch = levelSwitch;
            _popupManager = popupManager;
            _levelsConfig = levelsConfig;
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
            
            InitLevelCards(gridLayout.gameObject, _levelCardPrefab, _levelsConfig);
            
            popupWrapper.Show();
        }
        
        private void InitLevelCards(GameObject parent, GameObject levelCardPrefab, List<LevelCardSO> levelsConfig)
        {
            foreach (var level in levelsConfig)
            {
                GameObject levelObj = _gameObjectHolder.InstantiateByPrefab(levelCardPrefab, parent.transform);

                if (levelObj.TryGetComponent(out LevelCard card))
                {
                    card.Title.SetText(level.Name);
                    card.Icon.sprite = level.Icon;
                    card.OnClick = () => _levelSwitch.GoToLevel(level.Scene.name);
                }
            }
        }
    }
}