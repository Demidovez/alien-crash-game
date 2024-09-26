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
            
            foreach (var enemyMarker in EnemyMarkers)
            {
                if (enemyMarker.isActiveAndEnabled)
                {
                    _enemyFactory.Create(enemyMarker.EnemyType, enemyMarker.InitialWayPoint, enemyMarker.transform.position);
                }
            }
        }
    }
}

