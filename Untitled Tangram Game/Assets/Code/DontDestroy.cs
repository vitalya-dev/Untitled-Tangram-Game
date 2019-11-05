using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    void Awake() {
        if (GameObject.Find(gameObject.name + "(Loaded)"))
            GameObject.Destroy(this.gameObject);
        else {
            DontDestroyOnLoad(this.gameObject);
            gameObject.name += "(Loaded)";
        }
    }
}