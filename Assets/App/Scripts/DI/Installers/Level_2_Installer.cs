using AlienSpace;
using EnemySpace;
using UnityEngine;
using Zenject;

namespace DISpace
{
    public class Level_2_Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEnemyFactory();
        }
        
        private void BindEnemyFactory()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}
