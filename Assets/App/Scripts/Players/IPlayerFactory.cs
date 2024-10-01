using UnityEngine;

namespace App.Scripts.Players
{
    public interface IPlayerFactory
    {
        void Load();
        void Create(Vector3 spawnPoint);
    }
}