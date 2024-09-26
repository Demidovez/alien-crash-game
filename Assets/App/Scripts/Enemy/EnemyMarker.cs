using App.Scripts.Entity;
using UnityEngine;

namespace App.Scripts.Enemy
{
    public class EnemyMarker: MonoBehaviour
    {
        public EEnemyType EnemyType;
        public EEntityRole EntityRole;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
            Gizmos.color = Color.white;
        }
    }
}