using UnityEngine;

namespace App.Scripts.Weapon
{
    public interface IEnemySpray
    {
        // ReSharper disable once InconsistentNaming
        public GameObject gameObject { get; }
        public void SprayTo(Transform target);
    }
}