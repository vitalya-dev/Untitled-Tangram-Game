using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HashWindow : EditorWindow {
    [MenuItem("Untitled Tangram Game/Show Hash Window")]
    public static void ShowWindow() {
        GetWindow<HashWindow>(false, "Hash", true);
    }

    void OnGUI() {
        GUILayout.Label(
            GameObject.Find("Game Logic").GetComponent<GameLogic>().get_shape_hash().ToString()
        );
    }
}