using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace App.Scripts.Levels
{
    public class LevelCard: MonoBehaviour
    {
        public TextMeshProUGUI Title;
        public Image Icon;
        public UnityAction OnClick;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }
}