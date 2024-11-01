﻿using System;
using System.Collections.Generic;
using App.Scripts.UI.Popups;
using App.Scripts.UI.Popups.LevelComplete;
using App.Scripts.UI.Popups.Levels;
using App.Scripts.UI.Popups.Questions;
using App.Scripts.UI.Popups.ShipDetailsCollected;
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
        public GameObject PopupQuestionPrefab;
        public GameObject PopupShipDetailsCollectedPrefab;
        public GameObject PopupLevelCompletePrefab;
        
        [Header("Levels")]
        public GameObject LevelCardPrefab;
        
        public override void InstallBindings()
        {
            BindPopupsContainer();
            BindPopupManager();
            BindLevelsPopup();
            BindQuestionPopup();
            BindShipDetailsCollectedPopup();
            BindLevelCompletePopup();
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
                .Bind(typeof(IPopupManager), typeof(IDisposable))
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
                .WithArguments(PopupLevelsPrefab, LevelCardPrefab);
        }
        
        private void BindQuestionPopup()
        {
            Container
                .Bind<IQuestionPopup>()
                .To<QuestionPopup>()
                .AsSingle()
                .WithArguments(PopupQuestionPrefab);
        }
        
        private void BindShipDetailsCollectedPopup()
        {
            Container
                .Bind<IShipDetailsCollectedPopup>()
                .To<ShipDetailsCollectedPopup>()
                .AsSingle()
                .WithArguments(PopupShipDetailsCollectedPrefab);
        }
        
        private void BindLevelCompletePopup()
        {
            Container
                .Bind<ILevelCompletePopup>()
                .To<LevelCompletePopup>()
                .AsSingle()
                .WithArguments(PopupLevelCompletePrefab);
        }
    }
}