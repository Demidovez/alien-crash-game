using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class GameObjectHolder : MonoBehaviour, IGameObjectHolder
    {
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