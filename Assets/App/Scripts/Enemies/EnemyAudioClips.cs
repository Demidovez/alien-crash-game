using System;
using UnityEngine;

namespace App.Scripts.Enemies
{
    [Serializable]
    public struct EnemyAudioClips
    {
        public AudioClip Damage;
        public AudioClip Concussion;
        public AudioClip[] FootsSteps;
    }
}