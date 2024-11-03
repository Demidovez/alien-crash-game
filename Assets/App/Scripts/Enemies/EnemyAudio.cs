using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace App.Scripts.Enemies
{
    public class EnemyAudio: IEnemyAudio, ILateTickable, IDisposable
    {
        private static readonly int Footstep = Animator.StringToHash("Footstep");
        
        private readonly EnemyAudioSource _audio;
        private readonly IEnemyHealth _enemyHealth;
        private readonly Animator _animator;

        private bool _isPlayingMoving;
        private float _lastFootStep;
        private float _lastTimeDamage;

        public EnemyAudio(
            EnemyAudioSource audioSource,
            IEnemyHealth enemyHealth,
            Animator animator
        )
        {
            _audio = audioSource;
            _enemyHealth = enemyHealth;
            _animator = animator;
            
            _enemyHealth.OnTookDamageEvent += DamageSound;
            _enemyHealth.OnConcussionEvent += ConcussionSound;
        }

        public void Dispose()
        {
            _enemyHealth.OnTookDamageEvent -= DamageSound;
            _enemyHealth.OnConcussionEvent -= ConcussionSound;
        }

        public void LateTick()
        {
            RunningSound();
        }
        
        private void ConcussionSound()
        { 
            _audio.Source.PlayOneShot(_audio.Clips.Concussion, 1f);
        }

        private void DamageSound(Transform obj)
        {
            var currentTime = Time.realtimeSinceStartup;

            if (currentTime - _lastTimeDamage > 0.75f)
            {
                _audio.Source.PlayOneShot(_audio.Clips.Damage, 0.3f);
                _lastTimeDamage = currentTime;
            }
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