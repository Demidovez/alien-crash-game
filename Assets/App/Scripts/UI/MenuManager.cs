using System;
using System.Collections.Generic;
using App.Scripts.UI.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public event Action<string> OnLoadLevelEvent;
        public event Action OnContinueLevelEvent;
        public event Action OnStartLevelEvent;
        public event Action OnExitGameEvent;

        [Header("Levels")] 
        public GridLayoutGroup LevelsGrid;
        public GameObject LevelCardPrefab;
        public List<LevelCardSO> LevelsConfig;
        public LevelsPopup LevelsPopup;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void Start()
        {
            InitLevelCards();
        }

        private void InitLevelCards()
        {
            foreach (var level in LevelsConfig)
            {
                GameObject levelObj = Instantiate(
                    LevelCardPrefab, 
                    LevelsGrid.transform.position,
                    Quaternion.identity,
                    LevelsGrid.transform
                );

                if (levelObj.TryGetComponent(out LevelCard card))
                {
                    card.Title.SetText(level.Name);
                    card.Icon.sprite = level.Icon;
                    card.OnClick = () => OnLoadLevelEvent?.Invoke(level.Scene.name);
                }
            }
        }

        public void ShowMenu()
        {
            gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            gameObject.SetActive(false);
        }

        public void OnLevelsToggle()
        {
            LevelsPopup.ToggleShow();
        }

        public void OnContinueClick()
        {
            OnContinueLevelEvent?.Invoke();
        }

        public void OnStartClick()
        {
            OnStartLevelEvent?.Invoke();
        }

        public void OnExitClick()
        {
            OnExitGameEvent?.Invoke();
        }
    }
}