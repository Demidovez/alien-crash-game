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

        private readonly Dictionary<float, PopupWrapper> _activePopups = new();

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

            _inputActionsManager.OnCancelKeyPressed += CloseLastPopup;
        }

        public void Dispose()
        {
            _inputActionsManager.OnCancelKeyPressed -= CloseLastPopup;
        }

        public PopupWrapper CreatePopupWrapper(bool canClose = true)
        {
            GameObject wrapper = _gameObjectHolder.InstantiateByPrefab(_popupWrapperPrefab, _popupsContainer.transform);

            if (wrapper.TryGetComponent(out PopupWrapper popupWrapper))
            {
                popupWrapper.OnClose = (id) => _activePopups.Remove(id);
                popupWrapper.Closable = canClose;
                
                _activePopups.Add(popupWrapper.Id, popupWrapper);
                
                return popupWrapper;
            }

            return null;
        }

        private void CloseLastPopup()
        {
            if (_activePopups.Count > 0)
            {
                PopupWrapper popup = _activePopups.Last().Value;

                if (popup.Closable)
                {
                    popup.Hide();
                }
            }
        }
    }
}