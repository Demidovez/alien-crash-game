using UnityEngine;
using Zenject;

namespace App.Scripts.HealthPills
{
    public class HealthPillFactory: IHealthPillFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string HealthPillPath = "HealthPill";
        private Object _healthPillPrefab;
        private Transform _healthPillsContainer;
        
        public HealthPillFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load()
        {
            _healthPillsContainer = new GameObject("HealthPills").transform;
            _healthPillPrefab = Resources.Load(HealthPillPath);
        }

        public void Create(Vector3 spawnPoint)
        {
            _diContainer.InstantiatePrefab(_healthPillPrefab, spawnPoint, Quaternion.identity, _healthPillsContainer);
        }
    }
}