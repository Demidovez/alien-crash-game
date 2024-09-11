using UnityEngine;

namespace EnemySpace
{
    public interface IEnemyFactory
    {
        void Load();
        void Create(EEnemyType enemyType, Vector3 spawnPoint);
    }
}