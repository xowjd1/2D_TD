using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint Waypoint => target as Waypoint;
    // Waypoint라는 속성은 현재 커스텀 에디터에서 다루고 있는 Waypoint 컴포넌트를 참조합니다.
    // target은 현재 편집 중인 오브젝트를 나타내고 Waypoint 클래스로 형변환하여 사용.


    private void OnSceneGUI()
    {
        Handles.color = Color.red;

        for(int i = 0; i < Waypoint.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            // Handles
            Vector3 currentWaypointPoint = Waypoint.CurrentPosition + Waypoint.Points[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            GUIStyle textStyle = new GUIStyle();
            textStyle.fontStyle = FontStyle.Bold;
            textStyle.fontSize = 16;
            textStyle.normal.textColor = Color.yellow;
            Vector3 textAlligent = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(Waypoint.CurrentPosition + Waypoint.Points[i] + textAlligent, $"{i + 1}", textStyle);

            EditorGUI.EndChangeCheck();

            if(EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                Waypoint.Points[i] = newWaypointPoint - Waypoint.CurrentPosition;
            }

        }
    }
}
