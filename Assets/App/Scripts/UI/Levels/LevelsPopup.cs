using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Levels
{
    public class LevelsPopup: MonoBehaviour, ILevelsPopup
    {
        public Image Background;
        public RectTransform Popup;

        private const float InitPopupYPosition = 950f;

        private void Awake()
        {
            Background.color = new Color(0,0,0,0);
            
            Vector3 position = Popup.localPosition;
            Popup.localPosition = new Vector3(position.x, InitPopupYPosition, position.z);
        }

        private void LateUpdate()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Hide();
            }
        }

        public void ToggleShow()
        {
            if (gameObject.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
        
        private void Show()
        {
            gameObject.SetActive(true);
            Background.DOFade(0.8f, 0.25f).SetUpdate(true);
            Popup.DOLocalMoveY(0, 0.25f).SetUpdate(true);
        }

        private void Hide()
        {
            Popup.DOLocalMoveY(InitPopupYPosition, 0.25f).SetUpdate(true);
            
            DOTween.Sequence()
                .Append(Background.DOFade(0f, 0.25f))
                .OnComplete(() => gameObject.SetActive(false))
                .SetUpdate(true);
        }
    }
}