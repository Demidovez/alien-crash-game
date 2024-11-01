using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public interface IShipDetailFactory
    {
        public void Load();
        public void Create(int index, Vector3 spawnPoint);
    }
}