using App.Scripts.UI;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class BootstrapInstaller : MonoInstaller
    {
        public SplashScreen SplashScreen;
        
        public override void InstallBindings()
        {
            BindSplashScreen();
        }

        private void BindSplashScreen()
        {
            Container
                .Bind<ISplashScreen>()
                .To<SplashScreen>()
                .FromInstance(SplashScreen)
                .AsSingle();
        }
    }
}