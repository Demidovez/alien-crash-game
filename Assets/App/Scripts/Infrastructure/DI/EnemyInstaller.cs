using System;
using App.Scripts.Common;
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
                .Bind(typeof(IEnemyHealth), typeof(IDisposable))
                .To<EnemyHealth>()
                .AsSingle()
                .WithArguments(ConcussionEffect);
        }

        private void BindEnemy()
        {
            Container
                .Bind(typeof(IEnemy), typeof(IDamageableWithAttacker))
                .To<Enemy>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyAttack()
        {
            Container
                .Bind(typeof(IEnemyAttack), typeof(ITickable))
                .To<EnemyAttack>()
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
                .Bind(typeof(IEnemyNavigation), typeof(IInitializable) , typeof(ITickable), typeof(IDisposable))
                .To<EnemyNavigation>()
                .AsSingle()
                .WithArguments(MinMoveSpeed, MaxMoveSpeed, ChaseSpeed, DeltaStopDistance);
        }

        private void BindEnemyAnimation()
        {
            Container
                .Bind(typeof(IEnemyAnimation), typeof(ITickable), typeof(IDisposable))
                .To<EnemyAnimation>()
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
                .To<FieldOfView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindEnemyChaseManager()
        {
            Container
                .Bind(typeof(IEnemyChaseManager), typeof(ITickable), typeof(IDisposable))
                .To<EnemyChaseManager>()
                .AsSingle();
        }
    }
}