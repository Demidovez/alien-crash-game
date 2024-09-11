using UnityEngine;
using Zenject;

namespace AlienSpace
{
    public class AlienAnimation : MonoBehaviour
    {
        [SerializeField] private float _animSmoothTime = 1f;

        private AlienMovement _alienMovement;
        private Animator _animator;
        private Vector2 _targetAnimPosition;
        private Vector2 _currentBlendAnim;
        private Vector2 _animVelocity;

        [Inject]
        public void Construct(AlienMovement alienMovement)
        {
            _alienMovement = alienMovement;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _targetAnimPosition = _alienMovement.MoveInput;
            
            _currentBlendAnim = Vector2.SmoothDamp(_currentBlendAnim, _targetAnimPosition, ref _animVelocity, _animSmoothTime * Time.deltaTime);
            
            _animator.SetFloat("Horizontal", _currentBlendAnim.x);
            _animator.SetFloat("Vertical", _currentBlendAnim.y);
            _animator.SetBool("IsGrounded", _alienMovement.IsGrounded);
        }
    }
}
