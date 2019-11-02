using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SelectUnityEvent : UnityEvent<Selectable, Vector2> { }

public class Selectable : MonoBehaviour {
    public SelectUnityEvent select_callback = new SelectUnityEvent();

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouse_position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            RaycastHit2D hit = Physics2D.Raycast(mouse_position, Vector2.zero);
            if (hit && hit.collider.gameObject == this.gameObject) {
                select(mouse_position);
            }
        }
    }

    public virtual void select(Vector2 mouse_position) {
        select_callback.Invoke(this, mouse_position);
    }
}