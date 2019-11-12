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
        level_restart(0);
    }

    public void level_restart(float delay) {
        StartCoroutine(__level_restart(delay));
    }

    private IEnumerator __level_restart(float delay) {
        if (level_loading != null && !level_loading.isDone)
            yield break;
        else
            yield return new WaitForSeconds(delay);
        /* ==================================== */
        foreach (var sound in FindObjectsOfType<AudioSource>())
            if (!sound.GetComponent<DontDestroy>() && sound.isPlaying) {
                sound.transform.parent = null;
                DontDestroyOnLoad(sound.gameObject);
                Destroy(sound.gameObject, 2.0f);
            }
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

    public void next_level(float delay) {
        StartCoroutine(__next_level(delay));
    }

    private IEnumerator __next_level(float delay) {
        if (level_loading != null && !level_loading.isDone)
            yield break;
        else
            yield return new WaitForSeconds(delay);

        /* ==================================== */
        foreach (var sound in FindObjectsOfType<AudioSource>())
            if (!sound.GetComponent<DontDestroy>() && sound.isPlaying) {
                sound.transform.parent = null;
                DontDestroyOnLoad(sound.gameObject);
                Destroy(sound.gameObject, 2.0f);
            }
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