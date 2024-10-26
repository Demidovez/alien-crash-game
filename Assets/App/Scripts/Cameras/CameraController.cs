using Cinemachine;
using UnityEngine;

namespace App.Scripts.Cameras
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        public CinemachineVirtualCamera FallowCamera;

        public void SetTarget(Transform target)
        {
            FallowCamera.Follow = target;
            FallowCamera.LookAt = target;
        }

        public Transform GetCameraTransform()
        {
            return FallowCamera.transform;
        }
    }  
}

