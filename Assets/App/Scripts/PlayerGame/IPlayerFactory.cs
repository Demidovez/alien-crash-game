using UnityEngine;

namespace App.Scripts.PlayerGame
{
    public interface IPlayerFactory
    {
        void Load();
        void Create(Vector3 spawnPoint);
    }
}