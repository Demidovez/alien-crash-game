using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure;
using App.Scripts.InputActions;
using UnityEngine;

namespace App.Scripts.UI.Popups
{
    public class PopupManager : IPopupManager, IDisposable
    {
        private readonly IInputActionsManager _inputActionsManager;
        private readonly IGameObjectHolder _gameObjectHolder;
        private readonly IPopupsContainer _popupsContainer;
        private readonly GameObject _popupWrapperPrefab;

        public bool IsActive => _activePopups.Count > 0;

        private readonly List<PopupWrapper> _activePopups = new();

        public PopupManager(
            IInputActionsManager inputActionsManager, 
            IGameObjectHolder gameObjectHolder,
            IPopupsContainer popupsContainer,
            GameObject popupWrapperPrefab
        )
        {
            _inputActionsManager = inputActionsManager;
            _gameObjectHolder = gameObjectHolder;
            _popupsContainer = popupsContainer;
            _popupWrapperPrefab = popupWrapperPrefab;

            _inputActionsManager.OnCancelKeyPressed += ClosePopup;
        }

        public void Dispose()
        {
            _inputActionsManager.OnCancelKeyPressed -= ClosePopup;
        }

        public PopupWrapper CreatePopupWrapper()
        {
            GameObject wrapper = _gameObjectHolder.InstantiateByPrefab(_popupWrapperPrefab, _popupsContainer.transform);

            if (wrapper.TryGetComponent(out PopupWrapper popupWrapper))
            {
                _activePopups.Add(popupWrapper);
                return popupWrapper;
            }

            return null;
        }

        private void ClosePopup()
        {
            if (_activePopups.Count > 0)
            {
                PopupWrapper popup = _activePopups.Last();
                popup.Hide();
            }
        }
    }
}