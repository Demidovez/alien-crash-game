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
            _shipDetailCounter.SetCountAll(_shipDetailMarkersContainer.childCount);
            
            for (var i = 0; i < _shipDetailMarkersContainer.childCount; i++)
            {
                _shipDetailFactory.Create(i, _shipDetailMarkersContainer.GetChild(i).transform.position);
            }
        }
    }
}