using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyFactory: IEnemyFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string EnemiesFolder = "Enemies";
        private Object[] _enemiesPrefabs;
        private Transform _enemiesContainer;
        
        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _enemiesContainer = new GameObject("Enemies").transform;
            _enemiesPrefabs = Resources.LoadAll(EnemiesFolder);
        }

        public void Create(int index, EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint)
        {
            if (_enemiesPrefabs.Length == 0)
            {
                return;
            }
            
            Object enemyPrefab = _enemiesPrefabs[index % _enemiesPrefabs.Length];
            
            Enemy enemy = _diContainer
                .InstantiatePrefabForComponent<Enemy>(enemyPrefab, spawnPoint, Quaternion.identity, _enemiesContainer);

            enemy?.Init(initialWayPoint);
        }
    }
}