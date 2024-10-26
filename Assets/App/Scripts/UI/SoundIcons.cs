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

        private ISoundManager _soundManager;
        private bool _isActiveSounds;
        private bool _isActiveMusic;

        [Inject]
        public void Construct(ISoundManager soundManager)
        {
            _soundManager = soundManager;
        }

        private void Start()
        {
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            SoundsIcon.sprite = _soundManager.IsActiveSounds ? SoundOnIcon : SoundOffIcon;
            MusicIcon.sprite = _soundManager.IsActiveMusic ? MusicOnIcon : MusicOffIcon;
        }

        public void OnMusicClick()
        {
            _soundManager.ToggleMusic();

            UpdateIcons();
        }
        
        public void OnSoundClick()
        {
            _soundManager.ToggleSounds();
            
            UpdateIcons();
        }
    }
}