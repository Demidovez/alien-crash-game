using UnityEngine;
using Zenject;

namespace App.Scripts.GamePlayer
{
    public interface IPlayerFactory
    {
        void Load();
        void Create(Vector3 spawnPoint);
    }
}