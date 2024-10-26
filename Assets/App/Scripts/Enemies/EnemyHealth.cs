using System;
using System.Collections;
using App.Scripts.Infrastructure;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public class EnemyHealth: IEnemyHealth
    {
        public event Action<Transform> OnTookDamageEvent;
        public event Action OnConcussionEvent;
        public event Action OnOutFromConcussionEvent;
        
        public bool IsConcussion => _health <= 0;
        
        private readonly ICoroutineHolder _coroutineHolder;
        private readonly Transform _concussionEffectObj;
        private const float ConcussionDelay = 20f;
        private float _health = 100;

        public EnemyHealth(
            ICoroutineHolder coroutineHolder,
            Transform concussionEffectObj
        )
        {
            _coroutineHolder = coroutineHolder;
            _concussionEffectObj = concussionEffectObj;
        }

        public void TryTakeDamage(float value, Transform attacker)
        {
            if (_health <= 0)
            {
                return;
            }
            
            UpdateHealth(-value);

            if (_health > 0)
            {
                OnTookDamageEvent?.Invoke(attacker);
            }
        }

        private void UpdateHealth(float value)
        {
            _health += value;
            _health = Mathf.Min(100, _health);

            if (_health <= 0)
            {
                OnConcussionEvent?.Invoke();
                _coroutineHolder.StartCoroutine(Concussion());
            }
        }
        
        IEnumerator Concussion()
        {
            _concussionEffectObj.gameObject.SetActive(true);
            yield return new WaitForSeconds(ConcussionDelay);
            _health = 100f;
            _concussionEffectObj.gameObject.SetActive(false);
            
            OnOutFromConcussionEvent?.Invoke();
        }
    }
}