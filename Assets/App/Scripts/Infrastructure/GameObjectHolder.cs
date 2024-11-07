using System.Collections;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class GameObjectHolder : MonoBehaviour, IGameObjectHolder
    {
        public Coroutine LoadCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
        
        public void UnloadCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
        
        public GameObject InstantiateByPrefab(GameObject prefab, Transform parent, bool inFirstIndex = false)
        {
            if (parent)
            {
                GameObject child = Instantiate(prefab, parent.position, Quaternion.identity, parent);

                if (inFirstIndex)
                {
                    child.transform.SetSiblingIndex(0);
                }
                
                return child;
            }
            
            return Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
    }
}