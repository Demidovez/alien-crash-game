using UnityEngine;
using Zenject;

namespace EnemySpace
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

        public void Create(EEnemyType enemyType, Vector3 spawnPoint)
        {
            switch (enemyType)
            {
                case EEnemyType.Cop:
                    _diContainer.InstantiatePrefab(_copEnemyPrefab, spawnPoint, Quaternion.identity, null);
                    break;
                case EEnemyType.Farmer:
                    _diContainer.InstantiatePrefab(_farmerEnemyPrefab, spawnPoint, Quaternion.identity, null);
                    break;
                case EEnemyType.Ufologist:
                    _diContainer.InstantiatePrefab(_ufologistEnemyPrefab, spawnPoint, Quaternion.identity, null);
                    break;
            }
        }
    }
}