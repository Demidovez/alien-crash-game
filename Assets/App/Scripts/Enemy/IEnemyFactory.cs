using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemy
{
    public interface IEnemyFactory
    {
        void Load();
        void Create(int index, EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint);
    }
}