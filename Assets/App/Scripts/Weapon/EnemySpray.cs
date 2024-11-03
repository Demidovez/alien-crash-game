using System.Collections;
using App.Scripts.Bullets;
using App.Scripts.Common;
using UnityEngine;

namespace App.Scripts.Weapon
{
    public class EnemySpray : MonoBehaviour, IEnemySpray
    {
        public AudioSource AudioSource;
        public Transform SprayPoint;
        public LayerMask TargetLayerMask;
        
        private BulletsPool _bulletsPool;
        private const float DamageValue = 0.01f;
        private const float SprayDistance = 3.5f;

        private Coroutine _soundStopCoroutine;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _soundStopCoroutine = null;
        }

        public void SprayTo(Transform target)
        {
            if(Time.timeScale == 0)
            {
                AudioSource.mute = true;
                return;
            }
            
            AudioSource.mute = false;
            
            Vector3 direction = ((target.position + Vector3.up) - SprayPoint.position);
                
            if (Physics.Raycast(SprayPoint.position, direction, SprayDistance, TargetLayerMask))
            {
                if (target.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(DamageValue);
                }
            }

            PlayingSound();
        }

        private void PlayingSound()
        {
            if (_soundStopCoroutine != null)
            {
                StopCoroutine(_soundStopCoroutine);
            }
            else
            {
                AudioSource.Play();
            }
            
            _soundStopCoroutine = StartCoroutine(StopPlayingSound());
        }

        private IEnumerator StopPlayingSound()
        {
            yield return new WaitForSeconds(0.1f);
            AudioSource.Stop();
        }
    }
}