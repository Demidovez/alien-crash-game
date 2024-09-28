using UnityEngine;
using Zenject;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailSpawner : MonoBehaviour
    {
        public ShipDetailMarker[] ShipDetailMarkers;
        private IShipDetailFactory _shipDetailFactory;
        private ShipDetailCounter _shipDetailCounter;

        [Inject]
        public void Construct(IShipDetailFactory shipDetailFactory, ShipDetailCounter shipDetailCounter)
        {
            _shipDetailFactory = shipDetailFactory;
            _shipDetailCounter = shipDetailCounter;
        }
        
        private void Start()
        {
            _shipDetailFactory.Load();
            _shipDetailCounter.SetCountAll(ShipDetailMarkers.Length);
            
            for (var i = 0; i < ShipDetailMarkers.Length; i++)
            {
                _shipDetailFactory.Create(i, ShipDetailMarkers[i].transform.position);
            }
        }
    }
}