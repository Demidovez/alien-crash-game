using TMPro;
using UnityEngine;

namespace App.Scripts.UI.Popups
{
    public class SimplePopupContent: MonoBehaviour
    {
        public TextMeshProUGUI Title;
        public TextMeshProUGUI Text;

        public void SetTitle(string title)
        {
            Title.SetText(title);
        }
        
        public void SetText(string text)
        {
            Text.SetText(text);
        }
    }
}