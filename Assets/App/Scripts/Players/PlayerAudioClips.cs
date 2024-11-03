using System;
using UnityEngine;

namespace App.Scripts.Players
{
    [Serializable]
    public struct PlayerAudioClips
    {
        public AudioClip Jump;
        public AudioClip Landing;
        public AudioClip Damage;
        public AudioClip Death;
        public AudioClip[] FootsSteps;
    }
}