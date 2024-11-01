using UnityEngine;

namespace App.Scripts.Levels
{
    public class Level
    {
        public Sprite Icon { get; private set; }
        public string Name { get; private set; }
        public Object Scene { get; private set; }
        public Level Next { get; private set; }

        public Level(Sprite icon, string name, Object scene)
        {
            Icon = icon;
            Name = name;
            Scene = scene;
        }

        public void SetNext(Level next)
        {
            Next = next;
        }
    }
}