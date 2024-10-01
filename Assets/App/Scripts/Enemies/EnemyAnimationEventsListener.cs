using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyAnimationEventsListener : MonoBehaviour
    {
        private EnemyAttack _enemyAttack;
        
        [Inject]
        public void Construct(EnemyAttack enemyAttack)
        {
            _enemyAttack = enemyAttack;
        }
        
        public void AttackAnimationEvent()
        {
            _enemyAttack.TryAttack();
        }
    }
}