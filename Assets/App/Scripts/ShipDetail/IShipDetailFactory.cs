using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public interface IShipDetailFactory
    {
        void Load();
        void Create(Vector3 spawnPoint, int index);
    }
}