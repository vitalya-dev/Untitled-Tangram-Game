using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CollideUnityEvent : UnityEvent<GameObject, GameObject> { }

public class Shape : MonoBehaviour {
    public bool collided = false;
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
        collided = true;
    }
}