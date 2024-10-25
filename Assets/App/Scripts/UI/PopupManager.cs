using App.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace App.Scripts.UI
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private GameObject Background;
        [SerializeField] private GameObject CompleteCollectDetailsPopup;
        [SerializeField] private GameObject GameOverPopup;

        private Game _game; 

        [Inject]
        public void Construct(Game game)
        {
            _game = game;
        }
        
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