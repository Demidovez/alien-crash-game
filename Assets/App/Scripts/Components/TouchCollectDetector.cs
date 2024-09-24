using System.Collections;
using App.Scripts.Helpers;
using UnityEngine;

namespace App.Scripts.Components
{
    public class TouchCollectDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMaskAllowedEntities;
        
        private void OnTriggerEnter(Collider other)
        {
            if (Helper.ContainsLayer(other.gameObject.layer, _layerMaskAllowedEntities))
            {
                StartCoroutine(MoveToCollector(other.gameObject.transform));
            }
        }

        private IEnumerator MoveToCollector(Transform collector)
        {
            int countIterations = 1;
            
            while (enabled)
            {
                Vector3 targetPosition = new Vector3(collector.position.x, collector.position.y + collector.lossyScale.y, collector.position.z);
                
                transform.position = Vector3.Lerp(transform.position, targetPosition, countIterations * Time.deltaTime);
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, countIterations * Time.deltaTime);

                countIterations++;
                
                yield return null;
            }
        }
    }
}