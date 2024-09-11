using System;
using UnityEngine;

namespace AlienSpace
{
    public class Alien : MonoBehaviour
    {
        public Transform GetCameraPivot { get; private set; }
        
        private void Awake()
        {
            GetCameraPivot = transform.GetChild(0).transform;
        }
    }
}
