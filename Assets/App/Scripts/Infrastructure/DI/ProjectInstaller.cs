using System;
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
        public GameObject LoadingScreenPrefab;
        public GameObject PlayerInterfacePrefab;

        public override void InstallBindings()
        {
            BindGame();
            BindCoroutineHolder();
            BindInputManager();
            BindSceneLoader();
            BindCamera();
            BindSoundManager();
            BindMenuManager();
            BindLoadingScreen();
            BindPlayerInterfaceManager();
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
                .Bind<IGameObjectHolder>()
                .To<GameObjectHolder>()
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
                .Bind(typeof(IInputActionsManager), typeof(IInitializable), typeof(IDisposable))
                .To<InputActionsManager>()
                .AsSingle()
                .WithArguments(PlayerInput);
        }
    }
}

