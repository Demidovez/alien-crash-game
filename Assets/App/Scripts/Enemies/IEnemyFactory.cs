using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public interface IEnemyFactory
    {
        public void Load();
        public void Create(int index, EEnemyType enemyType, WayPoint initialWayPoint, Vector3 spawnPoint);
    }
}