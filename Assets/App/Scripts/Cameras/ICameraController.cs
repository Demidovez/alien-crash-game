using UnityEngine;

namespace App.Scripts.Cameras
{
    public interface ICameraController
    {
        public void SetTarget(Transform target);
        public Transform GetCameraTransform();
        public void DisableCamera();
    }
}