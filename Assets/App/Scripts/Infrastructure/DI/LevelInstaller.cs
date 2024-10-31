using System;
using App.Scripts.Bullets;
using App.Scripts.Enemies;
using App.Scripts.HealthPills;
using App.Scripts.LevelControllers;
using App.Scripts.Players;
using App.Scripts.ShipDetail;
using App.Scripts.Teleports;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class LevelInstaller : MonoInstaller
    {
        [Header("Player")]
        public Transform SpawnPlayerPoint;
        
        [Header("Enemies")]
        public Transform EnemyMarkersContainer;
        
        [Header("Ship details")]
        public Transform ShipDetailMarkersContainer;
        
        [Header("Health Pills")]
        public Transform HealthPillMarkersContainer;
        
        [Header("Teleports")]
        public Teleport Teleport;
        
        public override void InstallBindings()
        {
            BindLevelController();
            BindPlayerFactory();
            BindEnemyFactory();
            BindEnemiesSpawner();
            BindShipDetailFactory();
            BindShipDetailsCounter();
            BindShipDetailsSpawner();
            BindHealthPillsSpawner();
            BindHealthPillFactory();
            BindPlayerSpawner();
            BindBulletFactory();
            BindBulletsPool();
            BindTeleport();
        }

        private void BindLevelController()
        {
            Container
                .Bind(typeof(ILevelController), typeof(IInitializable), typeof(IDisposable))
                .To<LevelController>()
                .AsSingle();
        }

        private void BindBulletFactory()
        {
            Container
                .Bind<IBulletFactory>()
                .To<BulletFactory>()
                .AsTransient();
        }

        private void BindBulletsPool()
        {
            Container
                .Bind<IBulletsPool>()
                .To<BulletsPool>()
                .AsTransient();
        }

        private void BindHealthPillFactory()
        {
            Container
                .Bind<IHealthPillFactory>()
                .To<HealthPillFactory>()
                .AsSingle();
        }

        private void BindHealthPillsSpawner()
        {
            Container
                .Bind(typeof(IHealthPillsSpawner), typeof(IInitializable))
                .To<HealthPillsSpawner>()
                .AsSingle()
                .WithArguments(HealthPillMarkersContainer);
        }

        private void BindPlayerSpawner()
        {
            Container
                .Bind(typeof(IPlayerSpawner), typeof(IInitializable))
                .To<PlayerSpawner>()
                .AsSingle()
                .WithArguments(SpawnPlayerPoint);
        }

        private void BindShipDetailsSpawner()
        {
            Container
                .Bind(typeof(IShipDetailSpawner), typeof(IInitializable))
                .To<ShipDetailSpawner>()
                .AsSingle()
                .WithArguments(ShipDetailMarkersContainer);
        }

        private void BindEnemiesSpawner()
        {
            Container
                .Bind(typeof(IEnemySpawner), typeof(IInitializable))
                .To<EnemySpawner>()
                .AsSingle()
                .WithArguments(EnemyMarkersContainer);
        }

        private void BindShipDetailsCounter()
        {
            Container
                .Bind<IShipDetailCounter>()
                .To<ShipDetailCounter>()
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindPlayerFactory()
        {
            Container
                .Bind<IPlayerFactory>()
                .To<PlayerFactory>()
                .AsSingle();
        }
        
        private void BindShipDetailFactory()
        {
            Container
                .Bind<IShipDetailFactory>()
                .To<ShipDetailFactory>()
                .AsSingle();
        }
        
        private void BindTeleport()
        {
            Container
                .Bind<ITeleport>()
                .FromInstance(Teleport)
                .AsSingle();
        }
    }
}
