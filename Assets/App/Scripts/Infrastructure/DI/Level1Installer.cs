using App.Scripts.Enemies;
using App.Scripts.HealthPills;
using App.Scripts.Players;
using App.Scripts.ShipDetail;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class Level1Installer : MonoInstaller
    {
        [Header("Player")]
        public Transform SpawnPlayerPoint;
        
        [Header("Enemies")]
        public Transform EnemyMarkersContainer;
        
        [Header("Ship details")]
        public Transform ShipDetailMarkersContainer;
        public TMP_Text ShipDetailCountText;
        
        [Header("Health Pills")]
        public Transform HealthPillMarkersContainer;

        [Header("UI")] 
        public Image PlayerHealthBarLevel;
        
        public override void InstallBindings()
        {
            BindPlayerFactory();
            BindEnemyFactory();
            BindEnemiesSpawner();
            BindShipDetailFactory();
            BindShipDetailsCounter();
            BindShipDetailsSpawner();
            BindHealthPillsSpawner();
            BindHealthPillFactory();
            BindPlayerSpawner();
            BindPlayerInfoUI();
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
                .BindInterfacesTo<HealthPillsSpawner>()
                .AsSingle()
                .WithArguments(HealthPillMarkersContainer);
        }

        private void BindPlayerInfoUI()
        {
            Container
                .Bind<PlayerInfoUI>()
                .AsSingle()
                .WithArguments(PlayerHealthBarLevel);
        }

        private void BindPlayerSpawner()
        {
            Container
                .BindInterfacesTo<PlayerSpawner>()
                .AsSingle()
                .WithArguments(SpawnPlayerPoint);
        }

        private void BindShipDetailsSpawner()
        {
            Container
                .BindInterfacesTo<ShipDetailSpawner>()
                .AsSingle()
                .WithArguments(ShipDetailMarkersContainer);
        }

        private void BindEnemiesSpawner()
        {
            Container
                .BindInterfacesTo<EnemySpawner>()
                .AsSingle()
                .WithArguments(EnemyMarkersContainer);
        }

        private void BindShipDetailsCounter()
        {
            Container
                .BindInterfacesAndSelfTo<ShipDetailCounter>()
                .AsSingle()
                .WithArguments(ShipDetailCountText);
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
    }
}
