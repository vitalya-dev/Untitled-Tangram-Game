﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameLogic : MonoBehaviour {
    public GUIStyle gizmo_style = new GUIStyle();

    private GameObject shape = null;
    public void clicked(Clickable clickable, Vector2 mouse_position) {
        /* ================================================================= */
        if (clickable.tag == "Shape") {
            shape = clickable.gameObject;
        } else if (clickable.tag == "Field Piece" && shape != null) {
            /* ================================================================= */
            Vector2 offset = mouse_position - (Vector2)clickable.transform.position;
            offset.x = Mathf.Sign(offset.x);
            offset.y = Mathf.Sign(offset.y);
            /* ================================================================= */
            Vector3 new_position = shape.transform.position;
            new_position.x = clickable.gameObject.transform.position.x + 0.5f * offset.x;
            new_position.y = clickable.gameObject.transform.position.y + 0.5f * offset.y;
            /* ================================================================= */
            shape.transform.position = new_position;
            /* ================================================================= */
            shape = null;
        }
    }

    void OnDrawGizmos() {
#if UNITY_EDITOR
        Handles.Label(
            transform.position,
            "GameLogic: " + (shape ? shape.name : "None of shape selected"),
            gizmo_style
        );
#endif
    }

}