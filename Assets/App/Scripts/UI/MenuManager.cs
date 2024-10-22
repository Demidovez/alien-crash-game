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

        [Header("Icons")]
        public Sprite MusicOnIcon;
        public Sprite MusicOffIcon;
        public Sprite SoundOnIcon;
        public Sprite SoundOffIcon;

        [Header("Buttons")]
        public Button MusicButton;
        public Button SoundButton;
        public Button ContinueButton;
        public Button StartButton;
        public Button LevelsButton;
        public Button ExitButton;

        [Header("Levels")] 
        public GridLayoutGroup LevelsGrid;
        public GameObject LevelCardPrefab;
        public List<LevelCardSO> LevelsConfig;
        public LevelsPopup LevelsPopup;
        
        private List<LevelCard> _levels;

        private void Awake()
        {
            gameObject.SetActive(false);

            MusicButton.onClick.AddListener(OnMusicClick);
            SoundButton.onClick.AddListener(OnSoundClick);
            ContinueButton.onClick.AddListener(OnContinueClick);
            StartButton.onClick.AddListener(OnStartClick);
            LevelsButton.onClick.AddListener(OnLevelsToggle);
            ExitButton.onClick.AddListener(OnExitClick);
        }

        private void Start()
        {
            InitLevelCards();
        }

        private void InitLevelCards()
        {
            _levels = new List<LevelCard>();

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

                    _levels.Add(card);
                }
            }
        }

        private void OnDestroy()
        {
            MusicButton.onClick.RemoveListener(OnMusicClick);
            SoundButton.onClick.RemoveListener(OnSoundClick);
            ContinueButton.onClick.RemoveListener(OnContinueClick);
            StartButton.onClick.RemoveListener(OnStartClick);
            LevelsButton.onClick.RemoveListener(OnLevelsToggle);
            ExitButton.onClick.RemoveListener(OnExitClick);
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

        private void OnMusicClick()
        {
            Debug.Log("OnMusicClick");
        }

        private void OnExitClick()
        {
            Debug.Log("OnExitClick");
        }

        private void OnStartClick()
        {
            Debug.Log("OnStartClick");
        }

        private void OnContinueClick()
        {
            Debug.Log("OnContinueClick");
        }

        private void OnSoundClick()
        {
            Debug.Log("OnSoundClick");
        }
    }
}