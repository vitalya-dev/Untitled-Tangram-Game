using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MouseUnityEvent : UnityEvent<Vector3> { }

public class MouseInput : MonoBehaviour {
    public MouseUnityEvent on_lmb = new MouseUnityEvent();
    public MouseUnityEvent on_rmb = new MouseUnityEvent();

    void Update() {
        if (Input.GetMouseButtonDown(0))
            on_lmb.Invoke(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
            on_rmb.Invoke(Input.mousePosition);
    }
}