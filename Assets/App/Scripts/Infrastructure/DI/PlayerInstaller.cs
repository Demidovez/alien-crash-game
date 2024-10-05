using App.Scripts.Players;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class PlayerInstaller : MonoInstaller
    {
        public Transform WeaponShootPosition;
        
        public override void InstallBindings()
        {
            BindPlayerMovement();
            BindPlayerHealth();
            BindPlayerShooting();
        }

        private void BindPlayerShooting()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerShooting>()
                .AsSingle()
                .WithArguments(WeaponShootPosition);
        }

        private void BindPlayerHealth()
        {
            Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle();
        }

        private void BindPlayerMovement()
        {
            Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        }
    }
}