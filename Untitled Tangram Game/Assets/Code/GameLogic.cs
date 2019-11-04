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

    public UnityEvent on_win;

    public UnityEvent on_fail;

    public void shape_placed() {
        if (is_it_win())
            on_win.Invoke();
        if (is_it_fail())
            on_fail.Invoke();
    }

    public void debug(string message) {
        Debug.Log(message);
    }

    private bool is_it_win() {
        return Mathf.Abs(get_shape_hash() - target_shape_hash) <= 1;
    }

    private bool is_it_fail() {
        if (is_it_win())
            return false;
        for (int i = 0; i < shapes.transform.childCount; i++) {
            if (shapes.transform.GetChild(i).GetComponent<Selectable>().enabled)
                return false;
        }
        return true;
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

}