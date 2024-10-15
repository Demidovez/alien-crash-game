using App.Scripts.Enemies;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class EnemyHitAttackInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemyHit();
        }

        private void BindEnemyHit()
        {
            Container
                .Bind<IAttackMode>()
                .To<EnemyHitAttack>()
                .AsSingle();
        }
    }
}