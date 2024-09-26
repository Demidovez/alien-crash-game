using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemy
{
    public interface IEnemyFactory
    {
        void Load();
        void Create(EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint);
    }
}