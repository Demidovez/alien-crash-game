using UnityEngine;

namespace App.Scripts.ShipDetail
{
    public interface IShipDetailFactory
    {
        void Load();
        void Create(int index, Vector3 spawnPoint);
    }
}