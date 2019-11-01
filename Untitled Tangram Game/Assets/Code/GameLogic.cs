using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameLogic : MonoBehaviour {
    public GameObject shapes;

    public int target_shape_hash = 0;

    public GUIStyle gizmo_style = new GUIStyle();

    private Shape active_shape = null;

    public UnityEvent level_start;

    public UnityEvent level_complete_callback;

    public UnityEvent level_fail_callback;

    void Start() {
        level_start.Invoke();
    }

    public void clicked(Clickable clickable, Vector2 mouse_position) {
        if (clickable.tag == "Shape") {
            if (active_shape)
                active_shape.pivot.SetActive(false);
            active_shape = clickable.GetComponent<Shape>();
            active_shape.pivot.SetActive(true);
        } else if (clickable.tag == "Field Piece" && active_shape) {
            float size = 1.0f;
            if (clickable.GetComponent<BoxCollider2D>()) {
                size = clickable.GetComponent<BoxCollider2D>().size.x;
            }
            /* ================================================================= */
            Vector2 offset = mouse_position - (Vector2)clickable.transform.position;
            if (offset.magnitude < 0.2)
                return;
            else {
                offset.x = Mathf.Sign(offset.x);
                offset.y = Mathf.Sign(offset.y);
            }
            /* ================================================================= */
            Vector3 new_position = new Vector3();
            new_position.x = clickable.gameObject.transform.position.x + (size / 2) * offset.x;
            new_position.y = clickable.gameObject.transform.position.y + (size / 2) * offset.y;
            new_position.z = active_shape.transform.position.z;
            /* ================================================================= */
            active_shape.transform.position = new_position;
            /* ================================================================= */
            active_shape.GetComponent<Clickable>().enabled = false;
            /* ================================================================= */
            active_shape.pivot.SetActive(false);
            /* ================================================================= */
            active_shape = null;
            /* ================================================================= */
            if (is_it_done())
                level_complete_callback.Invoke();
            else if (is_it_fail())
                level_fail_callback.Invoke();
        }
    }

    public void collided(GameObject a, GameObject b) {
        Debug.Log("Collision:" + a.name + "," + b.name);
        if (a.GetComponent<Shape>())
            Destroy(a.gameObject);
    }

    void OnDrawGizmos() {
#if UNITY_EDITOR
        Handles.Label(
            transform.position,
            "GameLogic: " + (active_shape ? active_shape.name : "None of shape selected"),
            gizmo_style
        );
#endif
    }

    private bool is_it_done() {
        return Mathf.Abs(get_shape_hash() - target_shape_hash) <= 1;
    }

    public int get_shape_hash() {
        Vector3 hash_vec = Vector3.zero;
        for (int i = 1; i < shapes.transform.childCount; i++) {
            foreach (GameObject vertice in shapes.transform.GetChild(i).GetComponent<Shape>().vertices) {
                hash_vec +=
                    (shapes.transform.GetChild(0).GetComponent<Shape>().pivot.transform.position -
                    vertice.transform.position) * 1000;
            }
        }
        return (int)Mathf.Abs(hash_vec.x + hash_vec.y);
    }

    private bool is_it_fail() {
        if (is_it_done())
            return false;
        for (int i = 0; i < shapes.transform.childCount; i++) {
            if (shapes.transform.GetChild(i).GetComponent<Clickable>().enabled)
                return false;
        }
        return true;
    }

    public void level_restart() {
        if (GlobalVariables.attempts < GlobalVariables.max_attempts) {
            GlobalVariables.attempts += 1;
            Scene current_scene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(current_scene.buildIndex);
        }
    }

    public void debug(string message) {
        Debug.Log(message);
    }
}