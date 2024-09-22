﻿using UnityEngine;

namespace App.Scripts.Enemy
{
    public class EnemyMarker: MonoBehaviour
    {
        public EEnemyType EnemyType;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
            Gizmos.color = Color.white;
        }
    }
}