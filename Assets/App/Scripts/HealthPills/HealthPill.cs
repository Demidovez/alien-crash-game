using System;
using App.Scripts.Players;
using UnityEngine;

namespace App.Scripts.HealthPills
{
    public class HealthPill : MonoBehaviour, IHealthPill
    {
        private const float RegenerateValue = 10f;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHealthRegenerable healthRegenerable))
            {
                healthRegenerable.HealthRegenerate(RegenerateValue);
                Destroy(gameObject.transform.parent.parent.gameObject);
            }
        }
    }
}