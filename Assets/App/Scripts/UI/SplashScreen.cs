using System.Collections;
using App.Scripts.Infrastructure;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace App.Scripts.UI
{
    public class SplashScreen : MonoBehaviour, ISplashScreen
    {
        public CanvasGroup Screen;

        private IGame _game;
        private const float DelayTime = 1f;

        private float _startLoadingTime;

        [Inject]
        public void Construct(IGame game)
        {
            _game = game;
        }

        private void Awake()
        {
            _startLoadingTime = Time.realtimeSinceStartup;
            _game.OnBootedEvent += BootedGame;
        }

        private void OnDestroy()
        {
            _game.OnBootedEvent -= BootedGame;
        }

        private void BootedGame()
        {
            float loadingTime = Time.realtimeSinceStartup - _startLoadingTime;

            if (loadingTime >= DelayTime)
            {
                Hide();
            }
            else
            {
                StartCoroutine(WaitLoadingTime(loadingTime));
            }
        }

        private void Hide()
        {
            DOTween.Sequence()
                .Append(Screen.DOFade(0f, 0.5f))
                .OnComplete(() => Destroy(gameObject))
                .SetUpdate(true);
        }
        
        private IEnumerator WaitLoadingTime(float loadingTime)
        {
            yield return new WaitForSeconds(DelayTime - loadingTime);
            Hide();
        }
    }
}