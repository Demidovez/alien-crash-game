using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public class ShipDetail : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMaskAllowedEntities;
        
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & _layerMaskAllowedEntities) != 0)
            {
                Destroy(gameObject);
            }
        }
    }
}