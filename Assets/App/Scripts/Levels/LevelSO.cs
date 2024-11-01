using UnityEngine;

namespace App.Scripts.Levels
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Levels/Card")]
    public class LevelSO: ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public Object Scene;
        public int Order;
    }
}