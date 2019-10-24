﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CollideUnityEvent : UnityEvent<GameObject, GameObject> { }

public class Shape : MonoBehaviour {
    public CollideUnityEvent collide_callback = new CollideUnityEvent();
    public GameObject pivot;

    void Start() {
        if (transform.Find("Pivot")) {
            pivot = transform.Find("Pivot").gameObject;
            pivot.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        collide_callback.Invoke(gameObject, col.gameObject);
    }
}