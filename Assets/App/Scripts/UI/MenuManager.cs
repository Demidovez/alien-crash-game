using System;
using App.Scripts.Levels;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.UI
{
    public class MenuManager : MonoBehaviour, IMenuManager
    {
        public event Action OnBackToLevelEvent;
        public event Action OnStartLevelEvent;
        public event Action OnLevelsShowEvent;
        public event Action OnExitGameEvent;

        [Header("Menu Items")]
        public GameObject BackItem;
        public TextMeshProUGUI StartItemLabel;
        
        [Header("Level Info")]
        public GameObject LevelInfo;
        public Image LevelIcon;
        public TextMeshProUGUI LevelName;

        private ILevelsManager _levelsManager;

        [Inject]
        public void Construct(ILevelsManager levelsManager)
        {
            _levelsManager = levelsManager;
        }
        
        private void Awake()
        {
            gameObject.SetActive(false);
            BackItem.SetActive(false);
            LevelInfo.SetActive(false);
        }

        private void OnEnable()
        {
            if (_levelsManager.CanBackToLevel)
            {
                BackItem.SetActive(true);
            }

            UpdateStartItemLabel();
            UpdateLevelInfo();
        }
        
        private void OnDisable()
        {
            BackItem.SetActive(false);
            StartItemLabel.SetText("Начать");
            LevelInfo.SetActive(false);
        }

        public void ShowMenu()
        {
            gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            gameObject.SetActive(false);
        }

        public void OnLevelsClick()
        {
            OnLevelsShowEvent?.Invoke();
        }

        public void OnBackClick()
        {
            OnBackToLevelEvent?.Invoke();
        }

        public void OnStartClick()
        {
            OnStartLevelEvent?.Invoke();
        }

        public void OnExitClick()
        {
            OnExitGameEvent?.Invoke();
        }
        
        private void UpdateStartItemLabel()
        {
            if (_levelsManager.CurrentLevel == null)
            {
                StartItemLabel.SetText("Начать");
                return;
            }
            
            if (_levelsManager.CanBackToLevel)
            {
                StartItemLabel.SetText("Начать заново");
                return;
            }
            
            if (_levelsManager.CurrentLevel.IsCompleted)
            {
                StartItemLabel.SetText("Продолжить");
                return;
            }
            
            if (!_levelsManager.CurrentLevel.IsFirstLevel && !_levelsManager.CurrentLevel.IsLastLevel)
            {
                StartItemLabel.SetText("Продолжить");
                return;
            }
            
            StartItemLabel.SetText("Начать");
        }
        
        private void UpdateLevelInfo()
        {
            bool hasCurrentLevel = _levelsManager.CurrentLevel != null;
            bool isFirstUnStartedLevel = hasCurrentLevel && _levelsManager.IsFirstLevel && !_levelsManager.CurrentLevel.IsStarted;
            
            if (hasCurrentLevel && !isFirstUnStartedLevel)
            {
                LevelInfo.SetActive(true);
                LevelIcon.sprite = _levelsManager.CurrentLevel.Icon;
                LevelName.SetText(_levelsManager.CurrentLevel.Name);
            }
        }
    }
}