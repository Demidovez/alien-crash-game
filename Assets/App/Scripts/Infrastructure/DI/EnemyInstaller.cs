using App.Scripts.Components;
using App.Scripts.Enemies;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemyInstaller : MonoInstaller
    {
        [Header("Health")] 
        public Transform ConcussionEffect;
        
        [Header("Movement")]
        public float MinMoveSpeed = 0.75f;
        public float MaxMoveSpeed = 1.5f;
        public float ChaseSpeed = 5f;

        [Header("Navigation")] 
        public float DeltaStopDistance = 1.4f;
        
        public override void InstallBindings()
        {
            BindFieldOfView();
            BindEnemy();
            BindEnemyChaseManager();
            BindEnemyAttack();
            BindEnemyAnimator();
            BindEnemyAnimation();
            BindEnemyHealth();
            BindEnemyNavigation();
            BindEnemyNavMeshAgent();
        }

        private void BindEnemyHealth()
        {
            Container
                .Bind<EnemyHealth>()
                .AsSingle()
                .WithArguments(ConcussionEffect);
        }

        private void BindEnemy()
        {
            Container
                .BindInterfacesTo<Enemy>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyAttack()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyAttack>()
                .AsSingle();
        }

        private void BindEnemyNavMeshAgent()
        {
            Container
                .Bind<NavMeshAgent>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyNavigation()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyNavigation>()
                .AsSingle()
                .WithArguments(MinMoveSpeed, MaxMoveSpeed, ChaseSpeed, DeltaStopDistance);
        }

        private void BindEnemyAnimation()
        {
            Container
                .BindInterfacesTo<EnemyAnimation>()
                .AsSingle();
        }

        private void BindEnemyAnimator()
        {
            Container
                .Bind<Animator>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindFieldOfView()
        {
            Container
                .Bind<IFieldOfView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyChaseManager()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyChaseManager>()
                .AsSingle();
        }
    }
}