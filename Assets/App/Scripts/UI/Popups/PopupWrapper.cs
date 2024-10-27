using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Popups
{
    public class PopupWrapper: MonoBehaviour
    {
        public Image Background;
        public RectTransform Body;
        public Image CloseIcon;

        private const float InitPopupYPosition = 950f;

        private void Awake()
        {
            gameObject.SetActive(false);
            
            Background.color = new Color(0,0,0,0);
            
            Vector3 position = Body.localPosition;
            Body.localPosition = new Vector3(position.x, InitPopupYPosition, position.z);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            
            Background.DOFade(0.8f, 0.25f).SetUpdate(true);
            Body.DOLocalMoveY(0, 0.25f).SetUpdate(true);
        }

        public void Hide()
        {
            Body.DOLocalMoveY(InitPopupYPosition, 0.25f).SetUpdate(true);
            
            DOTween.Sequence()
                .Append(Background.DOFade(0f, 0.25f))
                .OnComplete(() => Destroy(gameObject))
                .SetUpdate(true);
        }
    }
}