using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    public void collided(GameObject a, GameObject b) {
        Debug.Log("Collision:" + a.name + "," + b.name);
        if (a.GetComponent<Shape>())
            Destroy(a.gameObject);
    }
}