using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.UI.Popups.Levels
{
    public class LevelCard: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public TextMeshProUGUI Title;
        public Image Icon;
        public UnityAction OnClick;
        public Texture2D TextureMouse;

        private RectTransform _rectTransform;
        private Image _background;
        private Color _initialColor;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _background = GetComponent<Image>();
            _initialColor = _background.color;
        }

        private void OnDestroy()
        {
            DOTween.Kill(_rectTransform);
            DOTween.Kill(_background);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Cursor.SetCursor(TextureMouse, new Vector2(20f, 0f), CursorMode.Auto);
            _background.DOFade(_initialColor.a * 2f, 0.35f).SetUpdate(true);
            _rectTransform.DOScale( new Vector3(1.05f,1.05f,1.05f), 0.35f).SetUpdate(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            _background.DOFade(_initialColor.a, 0.35f).SetUpdate(true);
            _rectTransform.DOScale( new Vector3(1f,1f,1f), 0.35f).SetUpdate(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }
    }
}