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
            BindGame();
            BindCoroutineHolder();
            BindInputManager();
            BindSceneLoader();
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

        private void BindGame()
        {
            Container
                .Bind<IGame>()
                .To<Game>()
                .AsSingle();
        }

        private void BindLoadingScreen()
        {
            Container
                .Bind<ILoadingScreen>()
                .To<LoadingScreen>()
                .FromComponentInNewPrefab(LoadingScreenPrefab)
                .AsSingle();
        }

        private void BindSoundManager()
        {
            Container
                .Bind<ISoundManager>()
                .To<SoundManager>()
                .AsSingle();
        }

        private void BindMenuManager()
        {
            Container
                .Bind<IMenuManager>()
                .To<MenuManager>()
                .FromComponentInNewPrefab(MenuPrefab)
                .AsSingle();
        }

        private void BindPlayerInterfaceManager()
        {
            Container
                .Bind<IPlayerInterfaceManager>()
                .To<PlayerInterfaceManager>()
                .FromComponentInNewPrefab(PlayerInterfacePrefab)
                .AsSingle();
        }

        private void BindPopupManager()
        {
            Container
                .Bind<IPopupManager>()
                .To<PopupManager>()
                .FromComponentInNewPrefab(PopupsPrefab)
                .AsSingle();
        }

        private void BindCamera()
        {
            Container
                .Bind<ICameraController>()
                .To<CameraController>()
                .FromComponentInNewPrefab(CameraPrefab)
                .AsSingle();
        }

        private void BindCoroutineHolder()
        {
            Container
                .Bind<ICoroutineHolder>()
                .To<CoroutineHolder>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindInputManager()
        {
            Container
                .BindInterfacesTo<InputActionsManager>()
                .AsSingle()
                .WithArguments(PlayerInput);
        }
    }
}

