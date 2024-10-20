using System;
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

        private void Awake()
        {
            gameObject.SetActive(false);

            MusicButton.onClick.AddListener(OnMusicClick);
            SoundButton.onClick.AddListener(OnSoundClick);
            ContinueButton.onClick.AddListener(OnContinueClick);
            StartButton.onClick.AddListener(OnStartClick);
            LevelsButton.onClick.AddListener(OnLevelsClick);
            ExitButton.onClick.AddListener(OnExitClick);
        }

        private void OnDestroy()
        {
            MusicButton.onClick.RemoveListener(OnMusicClick);
            SoundButton.onClick.RemoveListener(OnSoundClick);
            ContinueButton.onClick.RemoveListener(OnContinueClick);
            StartButton.onClick.RemoveListener(OnStartClick);
            LevelsButton.onClick.RemoveListener(OnLevelsClick);
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

        private void OnMusicClick()
        {
            Debug.Log("OnMusicClick");
        }
        
        private void OnExitClick()
        {
            Debug.Log("OnExitClick");
        }

        private void OnLevelsClick()
        {
            Debug.Log("OnLevelsClick");
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