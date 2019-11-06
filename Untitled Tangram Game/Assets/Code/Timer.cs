using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    public UnityEvent on_start = new UnityEvent();
    public UnityEvent on_finish = new UnityEvent();
    public UnityEvent on_ticktack = new UnityEvent();

    public int sec = 0;

    // Start is called before the first frame update
    void Start() {
        on_start.Invoke();
        StartCoroutine(timer(sec));
    }

    private IEnumerator timer(int s) {
        for (int i = 0; i < s; i++) {
            on_ticktack.Invoke();
            yield return new WaitForSeconds(1f);
        }
        on_finish.Invoke();
    }

    public void reset() {
        StopAllCoroutines();
        StartCoroutine(timer(sec));
    }
}