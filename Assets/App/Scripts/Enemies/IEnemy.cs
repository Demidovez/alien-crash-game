using App.Scripts.Tools.WayPoints;
using UnityEngine;

namespace App.Scripts.Enemies
{
    public interface IEnemy
    {
        public void Init(WayPoint initWayPoint);
        public void Damage(float damage, Transform attacker);
    }
}