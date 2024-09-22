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

            for (var i = 0; i < ShipDetailMarkers.Length; i++)
            {
                _shipDetailFactory.Create(ShipDetailMarkers[i].transform.position, i);
            }
        }
    }
}