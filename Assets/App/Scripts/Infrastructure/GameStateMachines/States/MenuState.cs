﻿using System;
using App.Scripts.InputActions;
using App.Scripts.Levels;
using App.Scripts.UI;
using App.Scripts.UI.Popups;
using App.Scripts.UI.Popups.Levels;
using App.Scripts.UI.Popups.Questions;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameStateMachines.States
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IMenuManager _menuManager;
        private readonly IInputActionsManager _inputActionsManager;
        private readonly IPopupManager _popupManager;
        private readonly ILevelsPopup _levelsPopup;
        private readonly IQuestionPopup _questionPopup;
        private readonly ILevelsManager _levelsManager;

        public MenuState(
            IGameStateMachine stateMachine, 
            IMenuManager menuManager,
            IInputActionsManager inputActionsManager,
            IPopupManager popupManager,
            ILevelsPopup levelsPopup,
            IQuestionPopup questionPopup,
            ILevelsManager levelsManager
        )
        {
            _stateMachine = stateMachine;
            _menuManager = menuManager;
            _inputActionsManager = inputActionsManager;
            _popupManager = popupManager;
            _levelsPopup = levelsPopup;
            _questionPopup = questionPopup;
            _levelsManager = levelsManager;
        }

        public void Enter()
        {
            _menuManager.ShowMenu();
            
            _menuManager.OnBackToLevelEvent += BackToLevel;
            _menuManager.OnStartLevelEvent += StartLevel;
            _menuManager.OnLevelsShowEvent += LevelsShow;
            _menuManager.OnExitGameEvent += ExitGame;
            
            _inputActionsManager.OnCancelKeyPressed += BackToLevel;
        }

        public void Exit()
        {
            _menuManager.HideMenu();
            
            _menuManager.OnBackToLevelEvent -= BackToLevel;
            _menuManager.OnStartLevelEvent -= StartLevel;
            _menuManager.OnLevelsShowEvent -= LevelsShow;
            _menuManager.OnExitGameEvent -= ExitGame;
            
            _inputActionsManager.OnCancelKeyPressed -= BackToLevel;
        }

        private void BackToLevel()
        {
            if (_levelsManager.CanBackToLevel && !_popupManager.IsActive)
            {
                _stateMachine.Enter<GameLoopState>();
            }
        }
        
        private void StartLevel()
        {
            _levelsManager.GoToCurrentLevel();
        }
        
        private void LevelsShow()
        {
            _levelsPopup.Show();
        }
        
        private void ExitGame()
        {
            Action exitAction = Application.Quit;
            
            #if UNITY_EDITOR
                exitAction = () => UnityEditor.EditorApplication.isPlaying = false;
            #endif
            
            _questionPopup.Show("Вы уверены?","Прогресс игры не сохранится!", "Выйти", exitAction);
        }
    }
}