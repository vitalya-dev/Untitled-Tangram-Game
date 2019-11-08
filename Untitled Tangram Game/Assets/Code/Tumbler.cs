using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbler : MonoBehaviour {
    public void tumb() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}