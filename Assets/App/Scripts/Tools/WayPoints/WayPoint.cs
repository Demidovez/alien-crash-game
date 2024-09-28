using UnityEngine;

namespace App.Scripts.Tools.WayPoints
{
    public class WayPoint : MonoBehaviour
    {
        public WayPoint Previous;
        public WayPoint Next;
        
        [Range(0f, 7f)] public float Width = 1f;
        
        public Vector3 LeftEdge => transform.position - (transform.right * Width / 2);
        public Vector3 RightEdge => transform.position + (transform.right * Width / 2);

        public Vector3 GetPosition()
        {
            return Vector3.Lerp(LeftEdge, RightEdge, Random.Range(0f, 1f));
        }
    }
}