using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : Clickable {
    public override void click_it() {
        Debug.Log("Click it" + gameObject.name);
    }
}