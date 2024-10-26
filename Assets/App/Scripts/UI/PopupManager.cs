using UnityEngine;

namespace App.Scripts.UI
{
    public class PopupManager : MonoBehaviour, IPopupManager
    {
        public GameObject Background;
        public GameObject CompleteCollectDetailsPopup;
        public GameObject GameOverPopup;

        public bool IsActive => _countActivePopups != 0;

        private float _countActivePopups;
        
        public void ShowCompleteCollectDetails()
        {
            _countActivePopups++;
            Time.timeScale = 0;
            
            Background.SetActive(true);
            CompleteCollectDetailsPopup.SetActive(true);
        }
        
        public void HideCompleteCollectDetails()
        {
            _countActivePopups--;
            Time.timeScale = 1;
            
            Background.SetActive(false);
            CompleteCollectDetailsPopup.SetActive(false);
        }
        
        public void ShowGameOver()
        {
            _countActivePopups++;
            Time.timeScale = 0;
            
            Background.SetActive(true);
            GameOverPopup.SetActive(true);
        }
        
        public void HideGameOver()
        {
            _countActivePopups--;
            Time.timeScale = 1;
            
            Background.SetActive(false);
            GameOverPopup.SetActive(false);
        }
    }
}