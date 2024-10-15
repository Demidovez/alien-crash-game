using App.Scripts.Enemies;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemyShootAttackInstaller : MonoInstaller
    {
        public Transform ShootStartPoint;
        
        public override void InstallBindings()
        {
            BindEnemyShoot();
        }

        private void BindEnemyShoot()
        {
            Container
                .Bind<IAttackMode>()
                .To<EnemyShootAttack>()
                .AsSingle()
                .WithArguments(ShootStartPoint);
        }
    }
}