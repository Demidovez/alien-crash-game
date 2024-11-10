using UnityEngine;

namespace App.Scripts.Levels
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Levels/Level")]
    public class LevelSO: ScriptableObject
    {
        public int Id;
        public Sprite Icon;
        public string Name;
        public string Scene;
    }
}