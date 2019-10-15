using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouse_position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            RaycastHit2D hit = Physics2D.Raycast(mouse_position, Vector2.zero);
            if (hit && hit.collider.gameObject == this.gameObject) {
                Debug.Log("Yeyyye we got a hit: " + this.gameObject.name);
            }
        }
    }

    public abstract void click_it();
}