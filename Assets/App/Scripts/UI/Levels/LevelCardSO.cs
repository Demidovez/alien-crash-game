using UnityEngine;

namespace App.Scripts.UI.Levels
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Levels/Card")]
    public class LevelCardSO: ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public Object Scene;
    }
}