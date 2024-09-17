using App.Scripts.Camera;
using App.Scripts.InputActions;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class ProjectInstaller : MonoInstaller
    {
        public PlayerInput PlayerInput;
        public GameObject CameraPrefab;
        
        public override void InstallBindings()
        {
            BindAsyncProcessor();
            BindGameStateMachine();
            BindInputManager();
            BindSceneLoader();
            BindGame();
            BindCamera();
        }
        
        private void BindGame()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
        }
        
        private void BindCamera()
        {
            Container
                .Bind<CameraController>()
                .FromComponentInNewPrefab(CameraPrefab)
                .AsSingle();
        }

        private void BindAsyncProcessor()
        {
            Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GameStateMachine>().AsSingle();
        }

        private void BindInputManager()
        {
            Container.Bind<InputActionsManager>()
                .AsSingle()
                .WithArguments(PlayerInput)
                .NonLazy();
        }
    }
}

