using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(bag))]
public class BagEditor : Editor
{
    private SerializedProperty itemImagesProperty;
    private SerializedProperty itemsProperty;
    private SerializedProperty mouse_img_Property;                  ///////////////////////////////////////////////////////////////
    private SerializedProperty description_Property;                  ///////////////////////////////////////////////////////////////

    private bool[] showItemSlots = new bool[bag.numItemSlots];

    private const string inventoryPropItemImagesName = "itemImages";
    private const string inventoryPropItemsName = "items";

    private const string mouse_img_Name = "mouse_img";              ///////////////////////////////////////////////////////////////
    private const string description_Name = "description";              ///////////////////////////////////////////////////////////////

    private void OnEnable()
    {
        itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
        itemsProperty = serializedObject.FindProperty(inventoryPropItemsName);
        mouse_img_Property = serializedObject.FindProperty(mouse_img_Name);         ////////////////////////////////////////////////////
        description_Property = serializedObject.FindProperty(description_Name);         ////////////////////////////////////////////////////
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(mouse_img_Property);                          ////////////////////////////////////////////////////
        EditorGUILayout.PropertyField(description_Property);                          ////////////////////////////////////////////////////

        for (int i = 0; i < bag.numItemSlots; i++)
        {
            ItemSlotGUI(i);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void ItemSlotGUI(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot" + index);

        if (showItemSlots[index])
        {
            EditorGUILayout.PropertyField(itemImagesProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(itemsProperty.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }   
}
