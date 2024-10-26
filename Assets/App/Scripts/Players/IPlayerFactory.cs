using UnityEngine;

namespace App.Scripts.Players
{
    public interface IPlayerFactory
    {
        public void Load();
        public void Create(Vector3 spawnPoint);
    }
}