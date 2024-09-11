using AlienSpace;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace CameraSpace
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _fallowCamera;

        [Inject]
        public void Construct(Alien alien)
        {
            _fallowCamera.Follow = alien.GetCameraPivot;
            _fallowCamera.LookAt = alien.GetCameraPivot;
        }
    }  
}

