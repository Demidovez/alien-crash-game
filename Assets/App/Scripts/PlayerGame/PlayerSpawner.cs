using UnityEngine;
using Zenject;

namespace App.Scripts.PlayerGame
{
    public class PlayerSpawner: IInitializable
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly Transform _spawnPoint;

        public PlayerSpawner(IPlayerFactory playerFactory, Transform spawnPoint)
        {
            _playerFactory = playerFactory;
            _spawnPoint = spawnPoint;
        }
        
        public void Initialize()
        {
            _playerFactory.Load();
            _playerFactory.Create(_spawnPoint.position);
        }
    }
}