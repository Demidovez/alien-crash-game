using App.Scripts.Helpers;
using App.Scripts.Levels;
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
        public GameObject EnterVFX;
        public GameObject EngineVFX;
        
        private Vector3 _currentRotation;

        private const float HeightToEscape = 30f;
        private Vector3 OffsetToEscape = 1000f * Vector3.forward + 1000f * Vector3.up;
        private float _fixedStateValue;
        private float _speedFlying;
        private bool _canFix;
        private bool _isEnteredInShip;
        private bool _canFly;
        private bool _isComplete;
        private Vector3 _initialStartPosition;
        
        private IPlayerActionsManager _playerActionsManager;
        private ILevelController _levelController;
        
        [Inject]
        public void Construct(
            IPlayerActionsManager playerActionsManager,
            ILevelController levelController
        )
        {
            _playerActionsManager = playerActionsManager;
            _levelController = levelController;
        }

        private void Update()
        {
            UpdateState();
            WaitEnterToShip();
            PrepareToEscape();
            StartingEscape();
        }

        private void StartingEscape()
        {
            if (_canFly)
            {
                _speedFlying += 0.01f;
                
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-35, 0, 0), _speedFlying * Time.deltaTime / 10f);
                transform.position = Vector3.Lerp(transform.position, _initialStartPosition + OffsetToEscape, _speedFlying * Time.deltaTime / 100f);
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, _speedFlying * Time.deltaTime / 5f);

                if (!_isComplete && transform.localScale.x <= 0.1f)
                {
                    _isComplete = true;
                    _levelController.WholeGameComplete();
                }
            }
        }

        private void PrepareToEscape()
        {
            if (!_canFly && _isEnteredInShip)
            {
                var newPosition = _initialStartPosition + HeightToEscape * Vector3.up;
                
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
                
                if (newPosition.y - transform.position.y <= 1f)
                {
                    _canFly = true;
                    _initialStartPosition = transform.position;
                    EngineVFX.gameObject.SetActive(true);
                }
            }
        }

        private void WaitEnterToShip()
        {
            if (!_isEnteredInShip && _fixedStateValue >= 100f)
            {
                Collider[] targetInRadius = Physics.OverlapSphere(transform.position - 2 * Vector3.up, 1f, FixerLayerMask);

                if (targetInRadius.Length > 0)
                {
                    _isEnteredInShip = true;
                    EnterVFX.gameObject.SetActive(false);
                    _levelController.WholeGameAlmostComplete();
                    targetInRadius[0].gameObject.SetActive(false);
                }
            }
        }

        private void UpdateState()
        {
            if (Fixable && _canFix && Input.GetKey(KeyCode.E) && _fixedStateValue <= 100f)
            {
                _fixedStateValue += 0.05f;
                _playerActionsManager.FixCurrentValue = Mathf.Round(_fixedStateValue) + "%";
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * _fixedStateValue / 100f);
                transform.position =
                    new Vector3(transform.position.x, transform.position.y + 0.002f, transform.position.z);

                if (_fixedStateValue >= 100f)
                {
                    _initialStartPosition = transform.position;
                    EnterVFX.gameObject.SetActive(true);
                    ToggleFixingState(false);
                }

                if (_fixedStateValue >= 90f)
                {
                    SparksVFX.gameObject.SetActive(false);
                }
                else if (_fixedStateValue >= 60f)
                {
                    FireSmokeVFX.gameObject.SetActive(false);
                }
                else if (_fixedStateValue >= 35f)
                {
                    FireVFX.gameObject.SetActive(false);
                }
                else if (_fixedStateValue >= 20f)
                {
                    FireWallVFX.gameObject.SetActive(false);
                }
                else if (_fixedStateValue >= 10f)
                {
                    SunVFX.gameObject.SetActive(false);
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