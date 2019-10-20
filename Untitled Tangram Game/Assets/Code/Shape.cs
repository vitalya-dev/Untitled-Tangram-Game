using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    public GameObject pivot;

    void Start() {
        if (transform.Find("Pivot")) {
            pivot = transform.Find("Pivot").gameObject;
            pivot.SetActive(false);
        }
    }
}