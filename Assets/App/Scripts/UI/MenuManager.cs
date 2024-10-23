using System;
using System.Collections.Generic;
using App.Scripts.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public event Action<string> OnLoadLevelEvent;

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
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnLevelsToggle()
        {
            LevelsPopup.ToggleShow();
        }

        public void OnExitClick()
        {
            Debug.Log("OnExitClick");
        }

        public void OnStartClick()
        {
            Debug.Log("OnStartClick");
        }

        public void OnContinueClick()
        {
            Debug.Log("OnContinueClick");
        }
    }
}