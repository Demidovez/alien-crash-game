using UnityEngine;

namespace App.Scripts.Weapon
{
    public interface IEnemyPistol
    {
        // ReSharper disable once InconsistentNaming
        public GameObject gameObject { get; }
        public void ShootTo(Transform target);
    }
}