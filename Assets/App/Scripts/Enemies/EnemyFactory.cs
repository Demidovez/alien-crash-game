using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyFactory: IEnemyFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string EnemiesFarmersFolder = "Enemies/Farmers";
        private const string EnemiesCopsFolder = "Enemies/Cops";
        private Object[] _enemiesFarmersPrefabs;
        private Object[] _enemiesCopsPrefabs;
        private Transform _enemiesContainer;
        
        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _enemiesContainer = new GameObject("Enemies").transform;
            
            // TODO: это плохо, нужно переходить на ScriptableObjects
            _enemiesFarmersPrefabs = Resources.LoadAll(EnemiesFarmersFolder);
            _enemiesCopsPrefabs = Resources.LoadAll(EnemiesCopsFolder);
        }

        public void Create(int index, EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint)
        {
            Object[] enemiesPrefabs;

            switch (enemyType)
            {
                case EEnemyType.Farmer:
                    enemiesPrefabs = _enemiesFarmersPrefabs;
                    break;
                case EEnemyType.Cop:
                    enemiesPrefabs = _enemiesCopsPrefabs;
                    break;
                default:
                    enemiesPrefabs = null;
                    break;
            }
            
            if (enemiesPrefabs == null || enemiesPrefabs.Length == 0)
            {
                return;
            }
            
            Object enemyPrefab = enemiesPrefabs[index % enemiesPrefabs.Length];
            
            Enemy enemy = _diContainer
                .InstantiatePrefabForComponent<Enemy>(enemyPrefab, spawnPoint, Quaternion.identity, _enemiesContainer);

            enemy?.Init(initialWayPoint);
        }
    }
}