using UnityEngine;

namespace App.Scripts.Levels
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Levels/Card")]
    public class LevelCardSO: ScriptableObject
    {
        public Sprite Icon;
        public string Name;
    }
}