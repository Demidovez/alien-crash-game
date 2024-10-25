using App.Scripts.Cameras;
using App.Scripts.InputActions;
using App.Scripts.Sound;
using App.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class ProjectInstaller : MonoInstaller
    {
        public PlayerInput PlayerInput;
        public GameObject MenuPrefab;
        public GameObject CameraPrefab;
        public GameObject PopupsPrefab;
        public GameObject LoadingScreenPrefab;
        public GameObject PlayerInterfacePrefab;

        public override void InstallBindings()
        {
            BindBoot();
            BindAsyncProcessor();
            BindInputManager();
            BindSceneLoader();
            BindGame();
            BindCamera();
            BindSoundManager();
            BindPopupManager();
            BindMenuManager();
            BindLoadingScreen();
            BindPlayerInterfaceManager();
        }

        private void BindBoot()
        {
            Container
                .BindInterfacesTo<Boot>()
                .AsSingle();
        }

        private void BindLoadingScreen()
        {
            Container
                .Bind<LoadingScreen>()
                .FromComponentInNewPrefab(LoadingScreenPrefab)
                .AsSingle();
        }

        private void BindSoundManager()
        {
            Container
                .Bind<SoundManager>()
                .AsSingle();
        }

        private void BindMenuManager()
        {
            Container
                .Bind<MenuManager>()
                .FromComponentInNewPrefab(MenuPrefab)
                .AsSingle();
        }

        private void BindPlayerInterfaceManager()
        {
            Container
                .Bind<PlayerInterfaceManager>()
                .FromComponentInNewPrefab(PlayerInterfacePrefab)
                .AsSingle();
        }

        private void BindPopupManager()
        {
            Container
                .Bind<PopupManager>()
                .FromComponentInNewPrefab(PopupsPrefab)
                .AsSingle();
        }

        private void BindGame()
        {
            Container
                .Bind<Game>()
                .AsSingle();
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
            Container
                .Bind<AsyncProcessor>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindInputManager()
        {
            Container
                .BindInterfacesAndSelfTo<InputActionsManager>()
                .AsSingle()
                .WithArguments(PlayerInput);
        }
    }
}

