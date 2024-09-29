using App.Scripts.Enemies;
using UnityEngine;
using Zenject;

namespace App.Scripts.Components
{
    [RequireComponent(typeof(SphereCollider))]
    public class AttackTrigger : MonoBehaviour
    {
        private IAttacker _attacker;
        
        private void Awake()
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }

        [Inject]
        public void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _attacker.Attack();
        }
    }
}