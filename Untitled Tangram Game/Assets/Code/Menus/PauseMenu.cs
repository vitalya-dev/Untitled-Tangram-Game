using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    void OnEnable() {
        Time.timeScale = 1 - Time.timeScale;
        foreach (var audio in FindObjectsOfType<AudioSource>()) {
            audio.pitch = Time.timeScale;
        }
    }

    void OnDisable() {
        Time.timeScale = 1 - Time.timeScale;
        foreach (var audio in FindObjectsOfType<AudioSource>()) {
            audio.pitch = Time.timeScale;
        }
    }
}