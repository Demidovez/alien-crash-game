using UnityEngine;
using Zenject;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailSpawner : MonoBehaviour
    {
        public ShipDetailMarker[] ShipDetailMarkers;
        private IShipDetailFactory _shipDetailFactory;

        [Inject]
        public void Construct(IShipDetailFactory shipDetailFactory)
        {
            _shipDetailFactory = shipDetailFactory;
        }
        
        private void Start()
        {
            _shipDetailFactory.Load();
            
            foreach (var shipDetailMarker in ShipDetailMarkers)
            {
                _shipDetailFactory.Create(shipDetailMarker.transform.position);
            }
        }
    }
}