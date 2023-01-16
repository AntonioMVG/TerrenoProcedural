using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomTerrain))]
public class CustomTerrainEditor : Editor
{
    // Declaración de propiedades
    SerializedProperty scaleFactor;
    SerializedProperty myTexture;
    SerializedProperty inverted;
    SerializedProperty colorBlue;
    SerializedProperty colorGreen;

    // Foldouts
    bool showRandom = false;
    bool showTexture = false;
    bool showColor = false;

    public void OnEnable()
    {
        scaleFactor = serializedObject.FindProperty("scaleFactor");
        myTexture = serializedObject.FindProperty("myTexture");
        inverted = serializedObject.FindProperty("inverted");
        colorBlue = serializedObject.FindProperty("colorBlue");
        colorGreen = serializedObject.FindProperty("colorGreen");
    }

    public override void OnInspectorGUI()
    {
        CustomTerrain myTerrain = (CustomTerrain)target;

        serializedObject.Update();

        showRandom = EditorGUILayout.Foldout(showRandom, "Random Terrain");
        if (showRandom)
        {
            // Generación aleatoria del terreno
            EditorGUILayout.LabelField("Random terrain");
            EditorGUILayout.PropertyField(scaleFactor);

            if (GUILayout.Button("Generate random terrain"))
                myTerrain.RandomTerrain();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        showTexture = EditorGUILayout.Foldout(showTexture, "Texture Terrain");
        if (showTexture)
        {
            // Cargar textura del terreno
            EditorGUILayout.PropertyField(myTexture);
            EditorGUILayout.PropertyField(inverted);
            // Escalar
            EditorGUILayout.PropertyField(scaleFactor);

            if (GUILayout.Button("Load Texture"))
                myTerrain.LoadTextureToTerrain();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        showColor = EditorGUILayout.Foldout(showColor, "Color Terrain");
        if (showColor)
        {
            EditorGUILayout.PropertyField(colorBlue);
            EditorGUILayout.PropertyField(colorGreen);

            if (GUILayout.Button("Load Colors"))
                myTerrain.ColorTerrain();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        // Reset del terreno
        EditorGUILayout.LabelField("Reset terrain");

        if (GUILayout.Button("Reset terrain"))
            myTerrain.ResetTerrain();

        // Aplicar las modificaciones de las propiedades indicadas en el editor
        serializedObject.ApplyModifiedProperties();
    }
}
