using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailFactory: IShipDetailFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string ShipDetailFolder = "ShipDetails";
        private Object[] _shipDetailPrefabs;
        private Transform _shipDetailsContainer;
        
        public ShipDetailFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load()
        {
            _shipDetailsContainer = new GameObject("ShipDetails").transform;
            _shipDetailPrefabs = Resources.LoadAll(ShipDetailFolder);
        }

        public void Create(int index, Vector3 spawnPoint)
        {
            Object shipDetailPrefab = _shipDetailPrefabs[index % _shipDetailPrefabs.Length];
            
            _diContainer.InstantiatePrefab(shipDetailPrefab, spawnPoint, Quaternion.identity, _shipDetailsContainer);
        }
    }
}