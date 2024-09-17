using UnityEngine;
using Zenject;

namespace App.Scripts.PlayerGame
{
    public class PlayerSpawner: MonoBehaviour
    {
        public Transform SpawnPoint;
        
        private IPlayerFactory _playerFactory;

        [Inject]
        public void Construct(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        private void Start()
        {
            _playerFactory.Load();
            _playerFactory.Create(SpawnPoint.position);
        }
    }
}