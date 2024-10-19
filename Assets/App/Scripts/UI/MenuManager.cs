using System;
using UnityEngine;

namespace App.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public event Action<string> OnLoadLevelEvent;

        public void ShowMenu()
        {
            Time.timeScale = 0;
        }
        
        public void HideMenu()
        {
            Time.timeScale = 1;
        }

        public void LoadLevel()
        {
            OnLoadLevelEvent?.Invoke("Level_1");
        }
    }
}