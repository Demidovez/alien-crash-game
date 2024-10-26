using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemySpawner : IEnemySpawner, IInitializable
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly Transform _enemyMarkersContainer;

        public EnemySpawner(IEnemyFactory enemyFactory, Transform enemyMarkersContainer)
        {
            _enemyFactory = enemyFactory;
            _enemyMarkersContainer = enemyMarkersContainer;
        }
        
        public void Initialize()
        {
            _enemyFactory.Load();
            int index = 0;

            foreach (Transform markerTransform in _enemyMarkersContainer)
            {
                if (!markerTransform.gameObject.activeInHierarchy)
                {
                    continue;
                }
                
                if (markerTransform.gameObject.TryGetComponent(out EnemyMarker marker))
                {
                    _enemyFactory.Create(index, marker.EnemyType, marker.InitialWayPoint, marker.transform.position);
                    index++;
                } 
            }
        }
    }
}

