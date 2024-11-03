using System;
using App.Scripts.Players;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class PlayerInstaller : MonoInstaller
    {
        public Transform WeaponShootPosition;
        
        [Header("Audio")]
        public PlayerAudioSource AudioSource;
        
        public override void InstallBindings()
        {
            BindPlayer();
            BindPlayerMovement();
            BindPlayerHealth();
            BindPlayerShooting();
            BindPlayerAnimator();
            BindPlayerAudio();
        }

        private void BindPlayerAnimator()
        {
            Container
                .Bind<Animator>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindPlayer()
        {
            Container
                .Bind<IPlayer>()
                .To<Player>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindPlayerShooting()
        {
            Container
                .Bind(typeof(IPlayerShooting), typeof(IDisposable))
                .To<PlayerShooting>()
                .AsSingle()
                .WithArguments(WeaponShootPosition);
        }

        private void BindPlayerHealth()
        {
            Container
                .Bind<IPlayerHealth>()
                .To<PlayerHealth>()
                .AsSingle();
        }

        private void BindPlayerMovement()
        {
            Container
                .Bind<IPlayerMovement>()
                .To<PlayerMovement>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
        
        private void BindPlayerAudio()
        {
            Container
                .Bind(typeof(IPlayerAudio), typeof(ILateTickable), typeof(IDisposable))
                .To<PlayerAudio>()
                .AsSingle()
                .WithArguments(AudioSource);
        }
    }
}