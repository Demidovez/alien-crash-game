using System;
using App.Scripts.Helpers;
using App.Scripts.UI;
using UnityEngine;
using Zenject;

namespace App.Scripts.SpaceShips
{
    public class SpaceShip: MonoBehaviour, ISpaceShip
    {
        public LayerMask FixerLayerMask;
        public bool Fixable;
        
        [Header("Effects")]
        public GameObject SparksVFX;
        public GameObject FireSmokeVFX;
        public GameObject FireVFX;
        public GameObject FireWallVFX;
        public GameObject SunVFX;

        private Vector3 _fixedRotation = new Vector3(0f, 0f, 0f);
        private Vector3 _brokenRotation = new Vector3(5.625f, -6.488f, 4.9650f);
        private Vector3 _currentRotation;
        
        private float _fixedStateValue;
        private bool _canFix;
        private IPlayerActionsManager _playerActionsManager;

        [Inject]
        public void Construct(
            IPlayerActionsManager playerActionsManager
        )
        {
            _playerActionsManager = playerActionsManager;
        }

        private void Update()
        {
            if (Fixable && _canFix && Input.GetKey(KeyCode.E) && _fixedStateValue <= 100f)
            {
                _fixedStateValue += 0.05f;
                _playerActionsManager.FixCurrentValue = Mathf.Round(_fixedStateValue) + "%";

                if (_fixedStateValue >= 100f)
                {
                    ToggleFixingState(false);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, FixerLayerMask) && Fixable && _fixedStateValue <= 100f)
            {
                ToggleFixingState(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, FixerLayerMask) && Fixable && _fixedStateValue <= 100f)
            {
                ToggleFixingState(false);
            }
        }

        private void ToggleFixingState(bool isActive)
        {
            _playerActionsManager.SetActivateFixing(isActive);
            _canFix = isActive;
        }
    }
}