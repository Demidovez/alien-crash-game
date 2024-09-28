using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemyMarker[] EnemyMarkers;
        private IEnemyFactory _enemyFactory;
        
        [Inject]
        public void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        private void Start()
        {
            _enemyFactory.Load();
            
            for (var i = 0; i < EnemyMarkers.Length; i++)
            {
                _enemyFactory.Create(i, EnemyMarkers[i].EnemyType, EnemyMarkers[i].InitialWayPoint, EnemyMarkers[i].transform.position);
            }
        }
    }
}

