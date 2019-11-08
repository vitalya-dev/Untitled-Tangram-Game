using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardInput : MonoBehaviour {
    public UnityEvent on_esc = new UnityEvent();

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
                on_esc.Invoke();
    }
}