using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public UnityEvent level_start;

    void Start() {
        level_start.Invoke();
    }

    public void level_restart() {
        if (GlobalVariables.attempts < GlobalVariables.max_attempts) {
            GlobalVariables.attempts += 1;
            Scene current_scene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(current_scene.buildIndex);
        } else {
            SceneManager.LoadSceneAsync(0);
            /* ==================================== */
            GlobalVariables.attempts = 0;
        }
    }

    public void next_level() {
        GlobalVariables.attempts = 0;
        /* ==================================== */
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(current_scene.buildIndex + 1);
    }
}