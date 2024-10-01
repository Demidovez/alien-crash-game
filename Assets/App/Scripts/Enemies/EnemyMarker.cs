using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public class EnemyMarker: MonoBehaviour
    {
        public EEnemyType EnemyType;
        public WayPoint InitialWayPoint;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
            Gizmos.color = Color.white;
        }
    }
}