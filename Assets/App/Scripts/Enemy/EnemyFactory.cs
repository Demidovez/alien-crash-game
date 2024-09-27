﻿using App.Scripts.Entity;
using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyFactory: IEnemyFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string EnemiesFolder = "Enemies";
        private Object[] _enemiesPrefabs;
        
        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _enemiesPrefabs = Resources.LoadAll(EnemiesFolder);
        }

        public void Create(EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint)
        {
            if (_enemiesPrefabs.Length == 0)
            {
                return;
            }
            
            Object enemyPrefab = _enemiesPrefabs[0];
            
            GameObject enemy = _diContainer.InstantiatePrefab(enemyPrefab, spawnPoint, Quaternion.identity, null);

            if (enemy.TryGetComponent(out IEntityNavigation navigation))
            {
                navigation.SetCurrentWayPoint(initialWayPoint);
            }
        }
    }
}