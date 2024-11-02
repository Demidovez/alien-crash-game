using System;
using App.Scripts.Levels;
using TMPro;
using UnityEngine;
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
        }

        private void OnEnable()
        {
            if (_levelsManager.CanBackToLevel)
            {
                BackItem.SetActive(true);
            }

            UpdateStartItemLabel();
        }

        private void OnDisable()
        {
            BackItem.SetActive(false);
            StartItemLabel.SetText("Начать");
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
    }
}