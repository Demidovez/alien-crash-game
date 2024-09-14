using App.Scripts.InputActions;
using UnityEngine.InputSystem;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class ProjectInstaller : MonoInstaller
    {
        public PlayerInput PlayerInput;
        
        public override void InstallBindings()
        {
            BindAsyncProcessor();
            BindGameStateMachine();
            BindInputManager();
            BindSceneLoader();
            BindGame();
        }
        
        private void BindGame()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
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

