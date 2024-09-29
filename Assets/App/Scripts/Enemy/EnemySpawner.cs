using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemySpawner : IInitializable
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
            
            for (var i = 0; i < _enemyMarkersContainer.childCount; i++)
            {
                if (_enemyMarkersContainer.GetChild(i).TryGetComponent(out EnemyMarker marker))
                {
                    _enemyFactory.Create(i, marker.EnemyType, marker.InitialWayPoint, marker.transform.position);
                }
            }
        }
    }
}

