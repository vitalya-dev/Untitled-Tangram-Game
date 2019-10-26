using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameLogic : MonoBehaviour {
    public GameObject shapes;

    public GameObject target_shape;
    public int target_shape_hash = 0;

    public GUIStyle gizmo_style = new GUIStyle();

    private Shape active_shape = null;

    void Start() {
        target_shape.SetActive(true);
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

    public void am_i_done() {
        Vector3 hash_vec = Vector3.zero;
        for (int i = 1; i < shapes.transform.childCount; i++) {
            hash_vec += (shapes.transform.GetChild(0).position - shapes.transform.GetChild(i).position) * i * 100;
        }
        int shape_hash = (int)Mathf.Abs(hash_vec.x + hash_vec.y + hash_vec.z);
        Debug.Log(shape_hash == target_shape_hash);
    }

    public void level_restart() {
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(current_scene.buildIndex);
    }
}