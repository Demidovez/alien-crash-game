using UnityEngine;

namespace App.Scripts.HealthPills
{
    public interface IHealthPillFactory
    {
        void Load();
        void Create(Vector3 spawnPoint);
    }
}