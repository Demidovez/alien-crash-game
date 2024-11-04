using System;
using System.Collections.Generic;
using App.Scripts.Cameras;
using App.Scripts.InputActions;
using App.Scripts.Levels;
using App.Scripts.Saving;
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
        
        [Header("Prefabs")]
        public GameObject MenuPrefab;
        public GameObject CameraPrefab;
        public GameObject LoadingScreenPrefab;
        public GameObject PlayerInterfacePrefab;
        
        [Header("Audio")] 
        public GameObject MusicGamePrefab;
        
        [Header("Player Actions")] 
        public GameObject PlayerActionsPrefab;
        
        [Header("Levels")]
        public List<LevelSO> LevelsConfig;

        public override void InstallBindings()
        {
            BindSavedData();
            BindGame();
            BindCoroutineHolder();
            BindInputManager();
            BindSceneLoader();
            BindCamera();
            BindSoundManager();
            BindMenuManager();
            BindLoadingScreen();
            BindPlayerInterfaceManager();
            BindLevelsData();
            BindMusicGame();
            BindPlayerActionsManager();
        }

        private void BindSavedData()
        {
            Container
                .Bind(typeof(ISavedData), typeof(IDisposable))
                .To<SavedData>()
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
                .Bind<IAudioManager>()
                .To<AudioManager>()
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
        
        private void BindLevelsData()
        {
            Container
                .Bind<ILevelsData>()
                .To<LevelsData>()
                .AsSingle()
                .WithArguments(LevelsConfig);
        }
        
        private void BindMusicGame()
        {
            Container
                .Bind<IMusicGame>()
                .To<MusicGame>()
                .FromComponentInNewPrefab(MusicGamePrefab)
                .AsSingle();
        }
        
        private void BindPlayerActionsManager()
        {
            Container
                .Bind<IPlayerActionsManager>()
                .To<PlayerActionsManager>()
                .FromComponentInNewPrefab(PlayerActionsPrefab)
                .AsSingle();
        }
    }
}

