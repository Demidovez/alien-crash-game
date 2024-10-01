using System;
using System.Collections;
using App.Scripts.Helpers;
using UnityEngine;

namespace App.Scripts.Components
{
    public class FieldOfView : MonoBehaviour, IFieldOfView
    {
        public float ViewRadius;
        [Range(0, 360)] 
        public float ViewAngle;
        public Transform VisibleTarget;
        
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _visibleMask;
        [SerializeField] private float _delayTimeFinding = 0.2f;

        public event Action<Transform> OnAddedVisibleTarget;
        public event Action<Transform> OnRemovedVisibleTarget;
        
        private void Start()
        {
            StartCoroutine(FindVisible());
        }
        
        private IEnumerator FindVisible()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(_delayTimeFinding);
                
                CheckVisibleTarget();
                FindVisibleTarget();
            }
        }

        private void FindVisibleTarget()
        {
            if (VisibleTarget)
            {
                return;
            }
            
            Collider[] targetInRadius = Physics.OverlapSphere(transform.position, ViewRadius, _visibleMask);
            
            for (int i = 0; i < targetInRadius.Length; i++)
            {
                Transform target = targetInRadius[i].transform;
                
                bool isTarget = Helper.ContainsLayer(target.gameObject.layer, _targetMask);
                
                if (isTarget && IsCurrentVisibleInAngleArea(target))
                {
                    OnAddedVisibleTarget?.Invoke(target);
                    VisibleTarget = target;
                    return;
                }
            }
        }

        private void CheckVisibleTarget()
        {
            if (VisibleTarget && !IsCurrentVisibleInSensitiveArea(VisibleTarget))
            {
                OnRemovedVisibleTarget?.Invoke(VisibleTarget);
                VisibleTarget = null;
            }
        }
        
        private bool IsCurrentVisibleInAngleArea(Transform target)
        {
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;

            bool inViewAngle = Vector3.Angle(transform.forward, directionToTarget) < ViewAngle / 2;

            if (!inViewAngle)
            {
                return false;
            }

            Vector3 startRay = transform.position + Vector3.up;
            if (Physics.Raycast(startRay, directionToTarget, out RaycastHit hitInfo, ViewRadius))
            {
                if (hitInfo.collider.gameObject == target.gameObject)
                {
                    return true;
                }
            }

            return false;
        }
        
        private bool IsCurrentVisibleInSensitiveArea(Transform target)
        {
            return (target.position - transform.position).sqrMagnitude <= (ViewRadius * ViewRadius);
        }
        
        public Vector3 DirectionFromAngle(float angleDegrees, bool isAngleGlobal)
        {
            if (!isAngleGlobal)
            {
                angleDegrees += transform.eulerAngles.y;
            }

            return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
        }
    }
}