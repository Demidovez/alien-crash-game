using System.Collections.Generic;
using App.Scripts.Infrastructure;
using UnityEngine;

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
            GameObject levels = _gameObjectHolder.InstantiateByPrefab(_popupLevelsPrefab, popupWrapper.Body.transform);
            
            if (popupWrapper != null)
            {
                InitLevelCards(levels, _levelCardPrefab, _levelsConfig);
            }
            
            Debug.Log("Show levels");
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