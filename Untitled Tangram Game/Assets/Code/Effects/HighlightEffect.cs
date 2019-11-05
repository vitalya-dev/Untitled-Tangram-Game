using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightEffect : MonoBehaviour {
    public Color highlight_color;
    
    private Color normal_color;

    void Start() {
        normal_color = GetComponent<SpriteRenderer>().color;
    }
    public void highlight(bool value) {
        GetComponent<SpriteRenderer>().color = value ? highlight_color : normal_color;
    }
}