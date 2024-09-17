using UnityEngine;
using Zenject;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailFactory: IShipDetailFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string ShipDetail = "ShipDetail";
        private Object _shipDetailPrefab;
        
        public ShipDetailFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load()
        {
            _shipDetailPrefab = Resources.Load(ShipDetail);
        }

        public void Create(Vector3 spawnPoint)
        {
            _diContainer.InstantiatePrefab(_shipDetailPrefab, spawnPoint, Quaternion.identity, null);
        }
    }
}