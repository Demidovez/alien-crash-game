using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public class GameObjectHolder : MonoBehaviour, IGameObjectHolder
    {
        public GameObject InstantiateByPrefab(GameObject prefab, Transform parent)
        {
            if (parent)
            {
                return Instantiate(prefab, parent.position, Quaternion.identity, parent);
            }
            
            return Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
    }
}