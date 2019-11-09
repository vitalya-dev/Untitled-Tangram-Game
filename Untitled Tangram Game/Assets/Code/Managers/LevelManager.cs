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

    private AsyncOperation level_loading = null;

    public void level_restart() {
        if (level_loading != null && !level_loading.isDone)
            return;
        /* ==================================== */
        if (GlobalVariables.attempts < GlobalVariables.max_attempts) {
            GlobalVariables.attempts += 1;
            Scene current_scene = SceneManager.GetActiveScene();
            level_loading = SceneManager.LoadSceneAsync(current_scene.buildIndex);
        } else {
            level_loading = SceneManager.LoadSceneAsync(1);
            /* ==================================== */
            GlobalVariables.attempts = 0;
        }
    }

    public void next_level() {
        if (level_loading != null && !level_loading.isDone)
            return;
        /* ==================================== */
        GlobalVariables.attempts = 0;
        /* ==================================== */
        Scene current_scene = SceneManager.GetActiveScene();
        if (current_scene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            level_loading = SceneManager.LoadSceneAsync(current_scene.buildIndex + 1);
        else
            level_loading = SceneManager.LoadSceneAsync(1);
    }
}