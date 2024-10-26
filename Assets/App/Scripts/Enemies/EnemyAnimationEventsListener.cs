using UnityEngine;
using Zenject;

namespace App.Scripts.Enemies
{
    public class EnemyAnimationEventsListener : MonoBehaviour
    {
        private IEnemyAttack _enemyAttack;
        
        [Inject]
        public void Construct(IEnemyAttack enemyAttack)
        {
            _enemyAttack = enemyAttack;
        }
        
        public void AttackAnimationEvent()
        {
            _enemyAttack.TryAttack();
        }
    }
}