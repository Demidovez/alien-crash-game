using UnityEngine;
using Zenject;

namespace App.Scripts.PlayerGame
{
    public class PlayerFactory: IPlayerFactory
    {
        private readonly DiContainer _diContainer;
        
        private const string Player = "Player";
        private Object _playerPrefab;
        
        public PlayerFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load()
        {
            _playerPrefab = Resources.Load(Player);
        }

        public void Create(Vector3 spawnPoint)
        {
            _diContainer.InstantiatePrefab(_playerPrefab, spawnPoint, Quaternion.identity, null);
        }
    }
}