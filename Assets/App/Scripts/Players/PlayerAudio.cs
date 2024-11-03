using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace App.Scripts.Players
{
    public class PlayerAudio: IPlayerAudio, ILateTickable, IDisposable
    {
        private static readonly int Footstep = Animator.StringToHash("Footstep");
        
        private readonly PlayerAudioSource _audio;
        private readonly IPlayerMovement _playerMovement;
        private readonly IPlayerHealth _playerHealth;
        private readonly Animator _animator;

        private bool _isPlayingMoving;
        private float _lastFootStep;

        public PlayerAudio(
            PlayerAudioSource audioSource,
            IPlayerMovement playerMovement,
            IPlayerHealth playerHealth,
            Animator animator
        )
        {
            _audio = audioSource;
            _playerMovement = playerMovement;
            _playerHealth = playerHealth;
            _animator = animator;

            _playerMovement.OnJumpedEvent += JumpSound;
            _playerMovement.OnLandingEvent += LandingSound;
            _playerHealth.OnTookDamageEvent += DamageSound;
            _playerHealth.OnDeadEvent += DeathSound;
        }

        public void Dispose()
        {
            _playerMovement.OnJumpedEvent -= JumpSound;
            _playerMovement.OnLandingEvent -= LandingSound;
            _playerHealth.OnTookDamageEvent -= DamageSound;
            _playerHealth.OnDeadEvent -= DeathSound;
        }

        public void LateTick()
        {
            RunningSound();
        }
        
        private void DeathSound()
        {
            _audio.Source.PlayOneShot(_audio.Clips.Death, 1f);
        }

        private void DamageSound()
        {
            _audio.Source.PlayOneShot(_audio.Clips.Damage, 0.3f);
        }

        private void JumpSound()
        {
            _audio.Source.PlayOneShot(_audio.Clips.Jump, 1f);
        }
        
        private void LandingSound()
        {
            _audio.Source.PlayOneShot(_audio.Clips.Landing, 0.25f);
        }

        private void RunningSound()
        {
            var footStep = _animator.GetFloat(Footstep);

            if (Mathf.Abs(footStep) < 0.00001f)
            {
                footStep = 0f;
            }

            if (_lastFootStep > 0 && footStep < 0 || _lastFootStep < 0 && footStep > 0)
            {
                var step = _audio.Clips.FootsSteps[Random.Range(0, _audio.Clips.FootsSteps.Length)];
                
                _audio.Source.PlayOneShot(step, 0.8f);
            }

            _lastFootStep = footStep;
        }
    }
}