using AlienSpace;
using CameraSpace;
using EnemySpace;
using UnityEngine;
using Zenject;

namespace DISpace
{
    public class Level_1_Installer : MonoInstaller
    {
        public GameObject AlienPrefab;
        // public GameObject AlienMovementPrefab;
        public Transform AlienSpawnPoint;
        
        public override void InstallBindings()
        {
            BindCamera();
            BindAlien();
            // BindAlienMovement();
            BindEnemyFactory();
        }

        // private void BindAlienMovement()
        // {
        //     AlienMovement alienMovement = 
        //         Container
        //             .InstantiatePrefabForComponent<AlienMovement>(
        //                 AlienMovementPrefab,
        //                 Vector3.zero,
        //                 Quaternion.identity,
        //                 null
        //             );
        //
        //     Container.Bind<AlienMovement>().FromInstance(alienMovement).AsSingle();
        // }

        private void BindCamera()
        {
            Container
                .Bind<CameraController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindAlien()
        {
            Alien alien = 
                Container
                    .InstantiatePrefabForComponent<Alien>(
                        AlienPrefab,
                        AlienSpawnPoint.position,
                        Quaternion.identity,
                        null
                    );
        
            Container.BindInterfacesAndSelfTo<Alien>().FromInstance(alien).AsSingle();
            // Container.QueueForInject(AlienPrefab);
        }
    }
}
