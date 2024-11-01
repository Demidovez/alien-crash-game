using System;
using TMPro;
using UnityEngine;

namespace App.Scripts.UI.Popups.Questions
{
    public class QuestionPopupLayout: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _text;
        
        [Header("Buttons")]
        [SerializeField] private TextMeshProUGUI _okText;
        [SerializeField] private TextMeshProUGUI _cancelText;

        public Action OnOkClick;
        public Action OnCancelClick;
        
        public string Title
        {
            get => _title.text;
            set => SetTextFor(_title, value);
        }
        
        public string Text
        {
            get => _text.text;
            set => SetTextFor(_text, value);
        }
        
        public string OkButtonLabel
        {
            get => _okText.text;
            set => _okText.SetText(value);
        }
        
        public string CancelButtonLabel
        {
            get => _cancelText.text;
            set => _cancelText.SetText(value);
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnOkClick?.Invoke();
            }
        }

        public void OnOkClickListener()
        {
            OnOkClick?.Invoke();
        }
        
        public void OnCancelClickListener()
        {
            OnCancelClick?.Invoke();
        }

        private void SetTextFor(TextMeshProUGUI textPro, string text)
        {
            textPro.gameObject.SetActive(true);
            textPro.SetText(text);
        }
    }
}