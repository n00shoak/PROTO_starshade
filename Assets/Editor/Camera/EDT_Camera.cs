using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DT_CameraStats))]
public class EDT_Camera : Editor
{
    private SerializedProperty X_Damping, Y_Damping, Z_Damping, Yaw_Damping;

    private SerializedProperty X_Offset, Y_Offset, Z_Offset;

    private SerializedProperty _followOffsetMinY, _followOffsetMaxY;
    private SerializedProperty _generalSpeed, _LshiftMultiplier;

    private SerializedProperty
        _keySpeedMultiplier,
        _edgeScrollSpeedMultiplier,
        _continuousRotationSpeedMultiplier,
        _pulseRotationSpeedMultiplier,
        _zoomSpeedMultiplier;


    private DT_CameraStats targetAssetCamStat;
    private bool displayDamping, displayOfsset, displayMovementStats;



    private void OnEnable()
    {
        X_Damping = serializedObject.FindProperty("Xdamping");
        Y_Damping = serializedObject.FindProperty("Ydamping");
        Z_Damping = serializedObject.FindProperty("Zdamping");
        Yaw_Damping = serializedObject.FindProperty("Yawdamping");

        X_Offset = serializedObject.FindProperty("Xoffset");
        Y_Offset = serializedObject.FindProperty("Yoffset");
        Z_Offset = serializedObject.FindProperty("Zoffset");

        _followOffsetMinY = serializedObject.FindProperty("followOffsetMinY");
        _followOffsetMaxY = serializedObject.FindProperty("followOffsetMaxY");
        _generalSpeed = serializedObject.FindProperty("generalSpeed");
        _LshiftMultiplier = serializedObject.FindProperty("LshiftMultiplier");

        _keySpeedMultiplier = serializedObject.FindProperty("keySpeedMultiplier");
        _edgeScrollSpeedMultiplier = serializedObject.FindProperty("edgeScrollSpeedMultiplier");
        _continuousRotationSpeedMultiplier = serializedObject.FindProperty("continuousRotationSpeedMultiplier");
        _pulseRotationSpeedMultiplier = serializedObject.FindProperty("pulseRotationSpeedMultiplier");
        _zoomSpeedMultiplier = serializedObject.FindProperty("zoomSpeedMultiplier");
    }

    public override void OnInspectorGUI()
    {
        displayDamping = EditorGUILayout.Foldout(displayDamping, "Mouvement Damping Stats", true);
        if (displayDamping)
        {
            DampingInfo();
        }

        displayOfsset = EditorGUILayout.Foldout(displayOfsset, "Position offset Stats", true);
        if (displayOfsset)
        {
            OffsetInfo();
        }

        displayMovementStats = EditorGUILayout.Foldout(displayMovementStats, "Camera movement Stats", true);
        if (displayMovementStats)
        {
            MovementStats();
        }

        if (GUILayout.Button("Apply Change"))
        {
            // oui oui
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DampingInfo()
    {
        SerializedProperty[] toPrint = new SerializedProperty[]
        {
            X_Damping,
            Y_Damping,
            Z_Damping,
        };
        PrintAll(toPrint);
    }

    private void OffsetInfo()
    {
        SerializedProperty[] toPrint = new SerializedProperty[]
        {
            X_Offset,
            Y_Offset,
            Z_Offset,
        };
        PrintAll(toPrint);
    }

    private void MovementStats()
    {
        SerializedProperty[] toPrint = new SerializedProperty[]
        {
            _followOffsetMinY,
            _followOffsetMaxY,
            _generalSpeed,
            _LshiftMultiplier,
            _keySpeedMultiplier,
            _edgeScrollSpeedMultiplier,
            _continuousRotationSpeedMultiplier,
            _pulseRotationSpeedMultiplier,
            _zoomSpeedMultiplier
        };
        PrintAll(toPrint);
    }

    private void PrintAll(SerializedProperty[] toPrint)
    {
        for (int i = 0; i < toPrint.Length; i++)
        {
            EditorGUILayout.PropertyField(toPrint[i]);
        }
        EditorGUILayout.LabelField($" ");
    }
}
