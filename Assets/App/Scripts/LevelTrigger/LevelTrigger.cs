using App.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace App.Scripts.LevelTrigger
{
    public class LevelTrigger : MonoBehaviour
    {
        [SerializeField] private string _nextLevel;
        [SerializeField] private LayerMask _layerMaskAllowedEntities;
        
        private Game _game;

        [Inject]
        public void Construct(Game game)
        {
            _game = game;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & _layerMaskAllowedEntities) != 0)
            {
                _game.ToNextLevel(_nextLevel);
            }
        }
    }
}

