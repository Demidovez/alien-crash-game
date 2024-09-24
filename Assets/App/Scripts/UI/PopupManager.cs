using UnityEngine;

namespace App.Scripts.UI
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private GameObject Background;
        [SerializeField] private GameObject CompleteCollectDetailsPopup;
        
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
    }
}