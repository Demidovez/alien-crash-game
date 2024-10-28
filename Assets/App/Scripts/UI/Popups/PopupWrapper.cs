using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Popups
{
    public class PopupWrapper: MonoBehaviour
    {
        public float Id { get; private set; }
        public Action<float> OnClose;
        public bool CanClose => OnClose != null;
        
        public Image Background;
        public RectTransform Body;
        public RectTransform CloseIcon;

        private const float InitPopupYPosition = 950f;

        private void Awake()
        {
            gameObject.SetActive(false);

            Id = Time.realtimeSinceStartup;
            Background.color = new Color(0,0,0,0);
            
            Vector3 position = Body.localPosition;
            Body.localPosition = new Vector3(position.x, InitPopupYPosition, position.z);
        }

        private void OnDestroy()
        {
            DOTween.Kill(Background);
            DOTween.Kill(Body);
        }

        public void OnClickListener()
        {
            Hide();
        }

        public void SetBodySize(float width, float height)
        {
            Body.sizeDelta = new Vector2(width, height);
        }

        public void Show()
        {
            gameObject.SetActive(true);

            if (!CanClose)
            {
                CloseIcon.gameObject.SetActive(false);
            }
            
            Background.DOFade(0.8f, 0.25f).SetUpdate(true);
            Body.DOLocalMoveY(0, 0.25f).SetUpdate(true);
        }

        public void Hide()
        {
            Body.DOLocalMoveY(InitPopupYPosition, 0.25f).SetUpdate(true);
            
            DOTween.Sequence()
                .Append(Background.DOFade(0f, 0.25f))
                .OnComplete(() => {
                    OnClose?.Invoke(Id);
                    Destroy(gameObject);
                })
                .SetUpdate(true);
        }
    }
}