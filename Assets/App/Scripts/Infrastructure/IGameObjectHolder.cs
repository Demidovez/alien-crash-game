using System.Collections;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public interface IGameObjectHolder
    {
        // ReSharper disable once InconsistentNaming
        public GameObject gameObject { get; }
        public Coroutine StartCoroutine(IEnumerator routine);
        public GameObject InstantiateByPrefab(GameObject prefab, Transform parent, bool inFirstIndex = false);
    }
}