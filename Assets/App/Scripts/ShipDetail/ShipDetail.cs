using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public class ShipDetail : MonoBehaviour, IShipDetail
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IShipDetailCollector collector))
            {
                collector.ShipDetailCollect();
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}