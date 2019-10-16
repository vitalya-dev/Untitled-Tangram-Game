using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public void clicked(Clickable clickable) {
        Debug.Log("Click click: " + clickable.name);
    }
}