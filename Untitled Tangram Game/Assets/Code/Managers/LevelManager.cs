using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public UnityEvent level_start;

    public string open_level;

    void Start() {
        level_start.Invoke();
    }

    private AsyncOperation level_loading = null;

    public void level_restart() {
        level_restart(0);
    }

    public void level_restart(float delay) {
        if (GlobalVariables.attempts < GlobalVariables.max_attempts) {
            GlobalVariables.attempts += 1;
            Scene current_scene = SceneManager.GetActiveScene();
            StartCoroutine(level_load(current_scene.buildIndex, delay));
        } else {
            StartCoroutine(level_load(-1, delay, open_level));
            GlobalVariables.attempts = 0;
        }
    }

    public void next_level(float delay) {
        GlobalVariables.attempts = 0;
        /* ==================================== */
        Scene current_scene = SceneManager.GetActiveScene();
        if (current_scene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            StartCoroutine(level_load(current_scene.buildIndex + 1, delay));
        else
            StartCoroutine(level_load(1, delay));
    }

    private IEnumerator level_load(int index, float delay, string name = "") {
        if (level_loading != null && !level_loading.isDone)
            yield break;
        else
            yield return new WaitForSeconds(delay);
        /* ==================================== */
        foreach (var sound in FindObjectsOfType<AudioSource>())
            if (!sound.GetComponent<DontDestroy>() && sound.isPlaying) {
                sound.transform.parent = null;
                DontDestroyOnLoad(sound.gameObject);
                Destroy(sound.gameObject, sound.clip.length);
            }
        /* ==================================== */
        if (name == "")
            level_loading = SceneManager.LoadSceneAsync(index);
        else
            level_loading = SceneManager.LoadSceneAsync(name);
    }
}