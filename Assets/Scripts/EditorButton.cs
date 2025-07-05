using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WorldGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        WorldGenerator worldGenerator = (WorldGenerator)target;
        if (GUILayout.Button("Generate Labirynth"))
        {
            worldGenerator.GenerateLabirynth();
        }
    }
}
