using UnityEngine;
using Zenject;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailSpawner: IShipDetailSpawner, IInitializable
    {
        private readonly IShipDetailFactory _shipDetailFactory;
        private readonly IShipDetailCounter _shipDetailCounter;
        private readonly Transform _shipDetailMarkersContainer;

        public ShipDetailSpawner(
            IShipDetailFactory shipDetailFactory, 
            IShipDetailCounter shipDetailCounter,
            Transform shipDetailMarkersContainer
        )
        {
            _shipDetailFactory = shipDetailFactory;
            _shipDetailCounter = shipDetailCounter;
            _shipDetailMarkersContainer = shipDetailMarkersContainer;
        }
        
        public void Initialize()
        {
            _shipDetailFactory.Load();

            int countMarkers = 0;

            if (_shipDetailMarkersContainer != null)
            {
                for (var i = 0; i < _shipDetailMarkersContainer.childCount; i++)
                {
                    Transform marker = _shipDetailMarkersContainer.GetChild(i);

                    if (marker.gameObject.activeSelf)
                    {
                        countMarkers++;
                        _shipDetailFactory.Create(i, marker.position);
                    }
                }
            }
            
            _shipDetailCounter.SetCountAll(countMarkers);
        }
    }
}