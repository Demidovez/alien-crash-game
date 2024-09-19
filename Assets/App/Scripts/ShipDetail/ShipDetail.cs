using App.Scripts.Helpers;
using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public class ShipDetail : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMaskAllowedEntities;
        
        private void OnTriggerEnter(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, _layerMaskAllowedEntities))
            {
                Destroy(gameObject);
            }
        }
    }
}