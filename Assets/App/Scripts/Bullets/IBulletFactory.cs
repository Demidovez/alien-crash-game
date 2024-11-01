using UnityEngine;

namespace App.Scripts.Bullets
{
    public interface IBulletFactory
    {
        public void Load(string bulletPrefabPath);
        public GameObject Create();
    }
}