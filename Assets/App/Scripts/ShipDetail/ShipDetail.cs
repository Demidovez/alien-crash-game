using System;
using App.Scripts.Helpers;
using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public class ShipDetail : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMaskAllowedEntities;

        public static event Action OnCollectedShipDetail;
        
        private void OnTriggerEnter(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, _layerMaskAllowedEntities))
            {
                OnCollectedShipDetail?.Invoke();
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}