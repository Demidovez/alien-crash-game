using App.Scripts.Helpers;
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
            if (Helper.ContainsLayer(other.gameObject.layer, _layerMaskAllowedEntities))
            {
                _game.ToNextLevel(_nextLevel);
            }
        }
    }
}

