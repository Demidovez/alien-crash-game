using UnityEngine;

namespace App.Scripts.UI
{
    public class PopupManager : MonoBehaviour, IPopupManager
    {
        public GameObject Background;
        public GameObject CompleteCollectDetailsPopup;
        public GameObject GameOverPopup;
        
        public void ShowCompleteCollectDetails()
        {
            Time.timeScale = 0;
            
            Background.SetActive(true);
            CompleteCollectDetailsPopup.SetActive(true);
        }
        
        public void HideCompleteCollectDetails()
        {
            Time.timeScale = 1;
            
            Background.SetActive(false);
            CompleteCollectDetailsPopup.SetActive(false);
        }
        
        public void ShowGameOver()
        {
            Time.timeScale = 0;
            
            Background.SetActive(true);
            GameOverPopup.SetActive(true);
        }
        
        public void HideGameOver()
        {
            Time.timeScale = 1;
            
            Background.SetActive(false);
            GameOverPopup.SetActive(false);
        }

        public void ShowMenu()
        {
            Time.timeScale = 0;
        }
        
        public void HideMenu()
        {
            Time.timeScale = 1;
        }
    }
}