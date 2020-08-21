#region Needed Library
//Connects us to unity
using UnityEngine;
//Allows us to make custom Edits to Unity
using UnityEditor;
//https://docs.unity3d.com/ScriptReference/UnityEditor.html
#endregion


//For making custom Window need to inherit from EditorWindow
public class RandomRotate : EditorWindow
{
    //MenuItem allows us to make an Item in your Menu so you can access your Window/Tool
    [MenuItem("Scrub Tools/Object Editor/Random Rotate")]
    //ShowWindow is a static void that runs when the window is selected so that it can Open
    public static void ShowWindow()
    {
        //GetWindow gets the window that is this script
        EditorWindow.GetWindow(typeof(RandomRotate));
    }

    /*
     OnGUI is called for rendering and handling GUI events.
     EditorGUI https://docs.unity3d.com/ScriptReference/EditorGUI.html
     EditorGUILayout https://docs.unity3d.com/ScriptReference/EditorGUILayout.html
         */
    public void OnGUI()
    {
        
    }
}
