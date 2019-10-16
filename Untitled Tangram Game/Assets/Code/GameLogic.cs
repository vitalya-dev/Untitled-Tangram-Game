using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameLogic : MonoBehaviour {
    public GUIStyle gizmo_style = new GUIStyle();

    private enum LogicFSM {
        GOT_NOTHING,
        GOT_SHAPE
    }
    private LogicFSM state = LogicFSM.GOT_NOTHING;

    public void clicked(Clickable clickable) {
        switch (state) {
            case LogicFSM.GOT_NOTHING:
                if (clickable.tag == "Shape")
                    state = LogicFSM.GOT_SHAPE;
                break;
            case LogicFSM.GOT_SHAPE:
                if (clickable.tag == "Field Piece") {
                    // Need move
                    state = LogicFSM.GOT_NOTHING;
                }
                break;
        }
    }

    void OnDrawGizmos() {
#if UNITY_EDITOR
        Handles.Label(transform.position + new Vector3(0.0f, 0.0f, 0), "GameLogic: " + state.ToString(), gizmo_style);
#endif
    }

}