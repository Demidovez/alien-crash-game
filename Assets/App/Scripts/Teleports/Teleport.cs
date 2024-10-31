using System;
using App.Scripts.Helpers;
using UnityEngine;

namespace App.Scripts.Teleports
{
    public class Teleport: MonoBehaviour, ITeleport
    {
        public event Action OnTeleportedEvent;
        
        public MeshRenderer AccessLight;
        public Material AllowLight;
        public Material DisallowLight;
        public GameObject Locker;
        public LayerMask AllowedLayerMask;
        
        public void SetActiveStatus(bool isActive)
        {
            var materials = AccessLight.materials;

            if (isActive)
            {
                materials[0] = AllowLight;
                Locker.SetActive(false);
            }
            else
            {
                materials[0] = DisallowLight;
                Locker.SetActive(true);
            }

            AccessLight.materials = materials;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, AllowedLayerMask))
            {
                other.gameObject.SetActive(false);
                OnTeleportedEvent?.Invoke();
            }
        }
    }
}