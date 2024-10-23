using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace App.Scripts.UI
{
    public class ClickListener: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public float ScaleValue = 1.05f;
        public RectTransform RectTransform;
        public Texture2D TextureMouse;
        public UnityEvent OnClick;

        public void OnPointerEnter(PointerEventData eventData)
        {
            Cursor.SetCursor(TextureMouse, new Vector2(20f, 0f), CursorMode.Auto);
            RectTransform.DOScale( new Vector3(ScaleValue,ScaleValue,ScaleValue), 0.35f).SetUpdate(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            RectTransform.DOScale( new Vector3(1f,1f,1f), 0.35f).SetUpdate(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}