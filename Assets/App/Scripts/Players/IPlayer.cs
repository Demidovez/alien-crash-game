using UnityEngine;

namespace App.Scripts.Players
{
    public interface IPlayer
    {
        // ReSharper disable once InconsistentNaming
        public Transform transform { get; }
        public void Damage(float damage);
    }
}