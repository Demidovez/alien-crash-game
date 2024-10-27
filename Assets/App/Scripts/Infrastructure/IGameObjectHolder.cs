using System.Collections;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public interface IGameObjectHolder
    {
        public Coroutine StartCoroutine(IEnumerator routine);
        public GameObject InstantiateByPrefab(GameObject prefab, Transform parent, bool inFirstIndex = false);
    }
}