using App.Scripts.Components;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.Editors
{
    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfViewEditor : Editor
    {
        private void OnSceneGUI()
        {
            FieldOfView fov = (FieldOfView) target;

            Handles.color = Color.green;

            float thickness = 2.0f;
            Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.ViewRadius, thickness);

            Vector3 viewLeftAngle = fov.DirectionFromAngle(-fov.ViewAngle / 2, false);
            Vector3 viewRightAngle = fov.DirectionFromAngle(fov.ViewAngle / 2, false);
            
            Handles.color = Color.blue;
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewLeftAngle * fov.ViewRadius);
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewRightAngle * fov.ViewRadius);
            
            Handles.color = Color.red;

            if (fov.VisibleTarget)
            {
                Handles.DrawLine(fov.transform.position, fov.VisibleTarget.position, thickness);
            }
        }
    }
}