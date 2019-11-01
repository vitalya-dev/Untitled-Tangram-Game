using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CollideUnityEvent : UnityEvent<GameObject, GameObject> { }

public class Shape : MonoBehaviour {
    public CollideUnityEvent collide_callback = new CollideUnityEvent();
    public GameObject pivot;
    public List<GameObject> vertices;

    void Start() {
        if (transform.Find("Pivot")) {
            pivot = transform.Find("Pivot").gameObject;
            pivot.SetActive(false);
        }
        foreach (Transform child in transform) {
            if (child.name == "Vertice") {
                vertices.Add(child.gameObject);
                child.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        collide_callback.Invoke(gameObject, col.gameObject);
    }
}