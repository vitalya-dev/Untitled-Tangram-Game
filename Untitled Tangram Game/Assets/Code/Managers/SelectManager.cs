﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SelectManager : MonoBehaviour {
    public GUIStyle gizmo_style = new GUIStyle();

    public UnityEvent on_shape_placed;
    public UnityEvent on_shape_collided;

    private Shape active_shape = null;

    public void shape_selected(Selectable shape, Vector2 mouse_position) {
        if (active_shape)
            active_shape.pivot.SetActive(false);
        active_shape = shape.GetComponent<Shape>();
        active_shape.pivot.SetActive(true);
    }

    public void field_selected(Selectable field, Vector2 mouse_position) {
        StartCoroutine(__field_selected(field, mouse_position));
    }
    private IEnumerator __field_selected(Selectable field, Vector2 mouse_position) {
        if (!active_shape)
            yield break;
        /* ================================================================= */
        float size = 1.0f;
        if (field.GetComponent<BoxCollider2D>()) {
            size = field.GetComponent<BoxCollider2D>().size.x;
        }
        /* ================================================================= */
        Vector2 offset = mouse_position - (Vector2)field.transform.position;
        if (offset.magnitude < 0.2)
            yield break;
        else {
            offset.x = Mathf.Sign(offset.x);
            offset.y = Mathf.Sign(offset.y);
        }
        /* ================================================================= */
        Vector3 new_position = new Vector3();
        new_position.x = field.gameObject.transform.position.x + (size / 2) * offset.x;
        new_position.y = field.gameObject.transform.position.y + (size / 2) * offset.y;
        new_position.z = active_shape.transform.position.z;
        /* ================================================================= */
        active_shape.transform.position = new_position;
        /* ================================================================= */
        active_shape.GetComponent<Selectable>().enabled = false;
        /* ================================================================= */
        active_shape.pivot.SetActive(false);
        /* ================================================================= */
        Physics2D.autoSimulation = false;
        Physics2D.Simulate(Time.fixedDeltaTime);
        Physics2D.autoSimulation = true;
        /* ================================================================= */
        if (active_shape.collided)
            on_shape_collided.Invoke();
        else
            on_shape_placed.Invoke();
        /* ================================================================= */
        active_shape = null;
    }

    void OnDrawGizmos() {
#if UNITY_EDITOR
        Handles.Label(
            transform.position + Vector3.right * 2,
            "Select manager: " + (active_shape ? active_shape.name : "None of shape selected"),
            gizmo_style
        );
#endif
    }

}