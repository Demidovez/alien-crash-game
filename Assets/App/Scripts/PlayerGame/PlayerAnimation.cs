using UnityEngine;
using Zenject;

namespace App.Scripts.PlayerGame
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private float _animSmoothTime = 1f;

        private PlayerMovement _playerMovement;
        private Animator _animator;
        private Vector2 _targetAnimPosition;
        private Vector2 _currentBlendAnim;
        private Vector2 _animVelocity;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");

        [Inject]
        public void Construct(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
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
        }
    }
}
