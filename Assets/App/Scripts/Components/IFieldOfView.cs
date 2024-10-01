using System;
using UnityEngine;

namespace App.Scripts.Components
{
    public interface IFieldOfView
    {
        public event Action<Transform> OnAddedVisibleTarget;
        public event Action<Transform> OnRemovedVisibleTarget;
    }
}