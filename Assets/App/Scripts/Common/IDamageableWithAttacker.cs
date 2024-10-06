using UnityEngine;

namespace App.Scripts.Common
{
    public interface IDamageableWithAttacker
    {
        public void Damage(float damage, Transform attacker);
    }
}