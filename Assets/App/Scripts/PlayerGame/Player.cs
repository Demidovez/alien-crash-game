using App.Scripts.Camera;
using UnityEngine;
using Zenject;

namespace App.Scripts.PlayerGame
{
    public class Player : MonoBehaviour
    {
        private CameraController _cameraController;

        [Inject]
        public void Construct(CameraController cameraController)
        {
            _cameraController = cameraController;
        }
        
        private void Awake()
        {
            Transform cameraPivot = transform.GetChild(0).transform;
            _cameraController.SetTarget(cameraPivot);
        }
    }
}
