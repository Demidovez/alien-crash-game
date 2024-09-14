using UnityEngine;

namespace App.Scripts.Enemy
{
    public interface IEnemyFactory
    {
        void Load();
        void Create(EEnemyType enemyType, Vector3 spawnPoint);
    }
}