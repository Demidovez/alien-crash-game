using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace App.Scripts.ShipDetail
{
    public class ShipDetailFactory: IShipDetailFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string ShipDetailFolder = "ShipDetails";
        private Object[] _shipDetailPrefabs;
        
        public ShipDetailFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load()
        {
            _shipDetailPrefabs = Resources.LoadAll(ShipDetailFolder);
        }

        public void Create(Vector3 spawnPoint)
        {
            Object shipDetailPrefab = _shipDetailPrefabs[Random.Range(0, _shipDetailPrefabs.Length)];
            
            _diContainer.InstantiatePrefab(shipDetailPrefab, spawnPoint, Quaternion.identity, null);
        }
    }
}