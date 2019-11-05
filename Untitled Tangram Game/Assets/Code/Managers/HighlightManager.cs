using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour {
    public void highlight(bool value) {
        foreach (var highlightable in FindObjectsOfType<HighlightEffect>()) {
            highlightable.highlight(value);
        }
    }
}