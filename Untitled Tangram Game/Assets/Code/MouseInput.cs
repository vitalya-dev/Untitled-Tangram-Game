using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MouseUnityEvent : UnityEvent<Vector3> { }

public class MouseInput : MonoBehaviour {
    public MouseUnityEvent lmb_callback = new MouseUnityEvent();
    public MouseUnityEvent rmb_callback = new MouseUnityEvent();

    void Update() {
        if (Input.GetMouseButtonDown(0))
            lmb_callback.Invoke(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
            rmb_callback.Invoke(Input.mousePosition);
    }
}