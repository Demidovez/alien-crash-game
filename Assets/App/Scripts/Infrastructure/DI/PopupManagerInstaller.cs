using System.Collections.Generic;
using App.Scripts.UI;
using App.Scripts.UI.Popups;
using App.Scripts.UI.Popups.Levels;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.DI
{
    public class PopupManagerInstaller : MonoInstaller
    {
        [Header("Popups Layout")]
        public GameObject PopupContainerPrefab;
        public GameObject PopupWrapperPrefab;
        
        [Header("Popups Content")]
        public GameObject PopupLevelsPrefab;
        public GameObject PopupYouSurePrefab;
        
        [Header("Levels")]
        public GameObject LevelCardPrefab;
        public List<LevelCardSO> LevelsConfig;
        
        public override void InstallBindings()
        {
            BindPopupsContainer();
            BindPopupManager();
            BindLevelsPopup();
        }

        private void BindPopupsContainer()
        {
            Container
                .Bind<IPopupsContainer>()
                .To<PopupsContainer>()
                .FromComponentInNewPrefab(PopupContainerPrefab)
                .AsSingle();
        }

        private void BindPopupManager()
        {
            Container
                .Bind<IPopupManager>()
                .To<PopupManager>()
                .AsSingle()
                .WithArguments(PopupWrapperPrefab);
        }

        private void BindLevelsPopup()
        {
            Container
                .Bind<ILevelsPopup>()
                .To<LevelsPopup>()
                .AsSingle()
                .WithArguments(LevelsConfig, PopupLevelsPrefab, LevelCardPrefab);
        }
        
        private void BindYouSurePopup()
        {
            Container
                .Bind<IYouSurePopup>()
                .To<YouSurePopup>()
                .AsTransient()
                .WithArguments(PopupYouSurePrefab);
        }
    }
}