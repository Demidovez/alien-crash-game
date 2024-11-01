using UnityEngine;

namespace App.Scripts.HealthPills
{
    public interface IHealthPillFactory
    {
        public void Load();
        public void Create(Vector3 spawnPoint);
    }
}