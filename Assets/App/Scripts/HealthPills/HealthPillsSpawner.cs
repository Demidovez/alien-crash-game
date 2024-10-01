using UnityEngine;
using Zenject;

namespace App.Scripts.HealthPills
{
    public class HealthPillsSpawner: IInitializable
    {
        private readonly IHealthPillFactory _healthPillFactory;
        private readonly Transform _healthPillMarkersContainer;

        public HealthPillsSpawner(
            IHealthPillFactory healthPillFactory, 
            Transform healthPillMarkersContainer
        )
        {
            _healthPillFactory = healthPillFactory;
            _healthPillMarkersContainer = healthPillMarkersContainer;
        }
        
        public void Initialize()
        {
            _healthPillFactory.Load();

            foreach (Transform marker in _healthPillMarkersContainer)
            {
                _healthPillFactory.Create(marker.position);
            }
        }
    }
}