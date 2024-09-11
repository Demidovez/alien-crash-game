using GameControllerSpace;
using InputActionsSpace;
using UnityEngine;
using Zenject;

namespace DISpace
{
    public class BootstrapInstaller : MonoInstaller
    {
        public GameObject InputActionsManagerPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<GameController>().AsSingle();
            Container.Bind<InputActionsManager>().FromComponentInNewPrefab(InputActionsManagerPrefab).AsSingle().NonLazy();
        }
    }
}

