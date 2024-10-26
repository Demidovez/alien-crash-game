using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public interface IEnemyNavigation
    {
        public bool IsReachedDestination { get; }
        public bool IsMoving { get; }
        public bool IsRunning { get; }
        public bool IsWaiting { get; }
        public Transform CurrentTransform { get; }

        public void SetCurrentWayPoint(WayPoint wayPoint);
        public void SetForceDestinationTarget(Transform target);
    }
}