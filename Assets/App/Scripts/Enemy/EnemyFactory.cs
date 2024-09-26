using App.Scripts.Entity;
using App.Scripts.Tools.WayPoints;
using UnityEngine;
using Zenject;

namespace App.Scripts.Enemy
{
    public class EnemyFactory: IEnemyFactory
    {
        private readonly DiContainer _diContainer;
        
        private Object _copEnemyPrefab;
        private Object _ufologistEnemyPrefab;
        private Object _farmerEnemyPrefab;

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _copEnemyPrefab = Resources.Load("EnemyBlue");
            _ufologistEnemyPrefab = Resources.Load("EnemyRed");
            _farmerEnemyPrefab = Resources.Load("EnemyPink");
        }

        public void Create(EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint)
        {
            Object enemyPrefab = null;
            
            switch (enemyType)
            {
                case EEnemyType.Cop:
                    enemyPrefab = _copEnemyPrefab;
                    break;
                case EEnemyType.Farmer:
                    enemyPrefab = _farmerEnemyPrefab;
                    break;
                case EEnemyType.Ufologist:
                    enemyPrefab = _ufologistEnemyPrefab;
                    break;
            }
            
            GameObject enemy = _diContainer.InstantiatePrefab(enemyPrefab, spawnPoint, Quaternion.identity, null);

            if (enemy.TryGetComponent(out IEntityNavigation navigation))
            {
                navigation.SetCurrentWayPoint(initialWayPoint);
            }
        }
    }
}