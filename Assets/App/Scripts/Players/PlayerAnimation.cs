using System;
using UnityEngine;
using Zenject;

namespace App.Scripts.Players
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private float _animSmoothTime = 1f;

        private IPlayerMovement _playerMovement;
        private IPlayerHealth _playerHealth;
        private IPlayerShooting _playerShooting;
        private Animator _animator;
        private Vector2 _targetAnimPosition;
        private Vector2 _currentBlendAnim;
        private Vector2 _animVelocity;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int UnderAttackTrigger = Animator.StringToHash("UnderAttackTrigger");
        private static readonly int DeadTrigger = Animator.StringToHash("DeadTrigger");
        private static readonly int ShootTrigger = Animator.StringToHash("ShootTrigger");

        [Inject]
        public void Construct(
            IPlayerMovement playerMovement,
            IPlayerHealth playerHealth,
            IPlayerShooting playerShooting
        )
        {
            _playerMovement = playerMovement;
            _playerHealth = playerHealth;
            _playerShooting = playerShooting;
        }

        private void Awake()
        {
            _playerHealth.OnTookDamageEvent += OnTookDamage;
            _playerHealth.OnDeadEvent += OnDead;
            _playerShooting.OnShootEvent += OnShoot;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _targetAnimPosition = _playerMovement.MoveInput;
            
            _currentBlendAnim = Vector2.SmoothDamp(_currentBlendAnim, _targetAnimPosition, ref _animVelocity, _animSmoothTime * Time.deltaTime);
            
            _animator.SetFloat(Horizontal, _currentBlendAnim.x);
            _animator.SetFloat(Vertical, _currentBlendAnim.y);
            _animator.SetBool(IsGrounded, _playerMovement.IsGrounded);
            _animator.SetBool(IsMoving, _playerMovement.IsMoving);
        }

        private void OnDestroy()
        {
            _playerHealth.OnTookDamageEvent -= OnTookDamage;
            _playerHealth.OnDeadEvent -= OnDead;
            _playerShooting.OnShootEvent -= OnShoot;
        }

        private void OnShoot()
        {
            _animator.SetTrigger(ShootTrigger);
        }

        private void OnTookDamage()
        {
            _animator.SetTrigger(UnderAttackTrigger);
        }
        
        private void OnDead()
        {
            _animator.SetTrigger(DeadTrigger);
        }
    }
}
