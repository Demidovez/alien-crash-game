using System;
using UnityEngine;

namespace App.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public event Action<string> OnLoadLevelEvent;

        private void Awake()
        {
            gameObject.SetActive(false);
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

        public void LoadLevel()
        {
            OnLoadLevelEvent?.Invoke("Level_1");
        }
    }
}