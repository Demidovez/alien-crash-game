using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EnemySpace
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
                _enemyFactory.Create(enemyMarker.EnemyType, enemyMarker.transform.position);
            }
        }
    }
}

