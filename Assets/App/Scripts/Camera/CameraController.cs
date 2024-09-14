using Cinemachine;
using UnityEngine;

namespace App.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _fallowCamera;

        public void SetTarget(Transform target)
        {
            _fallowCamera.Follow = target;
            _fallowCamera.LookAt = target;
        }

        public Transform GetCameraTransform()
        {
            return _fallowCamera.transform;
        }
    }  
}

