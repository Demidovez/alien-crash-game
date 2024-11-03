using App.Scripts.Sound;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.UI
{
    public class SoundIcons : MonoBehaviour
    {
        [Header("Icons")] 
        public Image SoundsIcon;
        public Image MusicIcon;
        
        [Header("Sprites")] 
        public Sprite MusicOnIcon;
        public Sprite MusicOffIcon;
        public Sprite SoundOnIcon;
        public Sprite SoundOffIcon;

        private IAudioManager _audioManager;
        private bool _isActiveSounds;
        private bool _isActiveMusic;

        [Inject]
        public void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        private void Start()
        {
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            SoundsIcon.sprite = _audioManager.IsActiveSounds ? SoundOnIcon : SoundOffIcon;
            MusicIcon.sprite = _audioManager.IsActiveMusic ? MusicOnIcon : MusicOffIcon;
        }

        public void OnMusicClick()
        {
            _audioManager.ToggleMusic();

            UpdateIcons();
        }
        
        public void OnSoundClick()
        {
            _audioManager.ToggleSounds();
            
            UpdateIcons();
        }
    }
}