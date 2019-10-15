using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Clickable {
    public override void click_it() {
        Debug.Log("Click it: " + name);
    }
}