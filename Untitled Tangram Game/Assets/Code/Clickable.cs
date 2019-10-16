using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ClickUnityEvent : UnityEvent<Clickable> { }

public class Clickable : MonoBehaviour {
    public ClickUnityEvent click_callback = new ClickUnityEvent();

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouse_position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            RaycastHit2D hit = Physics2D.Raycast(mouse_position, Vector2.zero);
            if (hit && hit.collider.gameObject == this.gameObject) {
                click_it();
            }
        }
    }

    public virtual void click_it() {
        click_callback.Invoke(this);
    }
}