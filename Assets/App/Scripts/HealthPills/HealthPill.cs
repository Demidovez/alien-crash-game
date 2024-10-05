using System;
using App.Scripts.Helpers;
using UnityEngine;

namespace App.Scripts.HealthPills
{
    public class HealthPill : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMaskAllowedEntities;

        public static event Action OnCollectedHealthPill;
        
        private void OnTriggerEnter(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, _layerMaskAllowedEntities))
            {
                OnCollectedHealthPill?.Invoke();
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}