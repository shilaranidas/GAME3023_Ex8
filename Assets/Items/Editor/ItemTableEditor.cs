using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemTable))]
//inheriting from editor means this thing can be used to make custom inspector
public class ItemTableEditor : Editor
{
    void OnEnable()//only in editor not in build
    {
        
    }
    //this will call when unity editor is rendering the inspector window
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        DrawDefaultInspector();
        ItemTable itemTable = (ItemTable)target;//target is the object that being edited, can cast to the specific derived class
        if (GUILayout.Button("Assign Items ids"))
            itemTable.AssignItemIDs(); 

    }
}
