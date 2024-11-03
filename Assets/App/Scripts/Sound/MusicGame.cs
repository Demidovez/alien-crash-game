using UnityEngine;

namespace App.Scripts.Sound
{
    public class MusicGame: MonoBehaviour, IMusicGame
    {
        public AudioSource AudioSource;

        public void ActiveMusic(bool isActive)
        {
            if (isActive)
            {
                AudioSource.Play();
            }
            else
            {
                AudioSource.Stop();
            }
        }
    }
}