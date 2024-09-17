using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailMarker : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.5f);
            Gizmos.color = Color.white;
        }
    }
}