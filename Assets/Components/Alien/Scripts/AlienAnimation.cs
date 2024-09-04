using UnityEngine;

namespace AlienSpace
{
    public class AlienAnimation : MonoBehaviour
    {
        [SerializeField] private float _animSmoothTime = 1f;
        
        private Animator _animator;
        private Vector2 _targetAnimPosition;
        private Vector2 _currentBlendAnim;
        private Vector2 _animVelocity;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _targetAnimPosition = AlienMovement.Instance.MoveInput;
            
            Debug.Log(_animSmoothTime);
            
            _currentBlendAnim = Vector2.SmoothDamp(_currentBlendAnim, _targetAnimPosition, ref _animVelocity, _animSmoothTime * Time.deltaTime);
            
            _animator.SetFloat("Horizontal", _currentBlendAnim.x);
            _animator.SetFloat("Vertical", _currentBlendAnim.y);
            _animator.SetBool("IsGrounded", AlienMovement.Instance.IsGrounded);
        }
    }
}
