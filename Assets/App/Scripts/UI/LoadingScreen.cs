using System.Collections;
using UnityEngine;

namespace App.Scripts.UI
{
    public class LoadingScreen: MonoBehaviour, ILoadingScreen
    {
        public CanvasGroup Screen;
        
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Screen.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(Hiding());
        }

        private IEnumerator Hiding()
        {
            yield return new WaitForSeconds(0.5f);
            
            while (Screen.alpha > 0)
            {
                Screen.alpha -= 0.02f;
                yield return new WaitForSeconds(0.01f);
            }
            
            gameObject.SetActive(false);
        }
    }
}