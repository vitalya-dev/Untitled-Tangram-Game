using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TimerUnityEvent : UnityEvent<float> { }

public class Timer : MonoBehaviour {
    public UnityEvent on_start = new UnityEvent();
    public UnityEvent on_finish = new UnityEvent();
    public TimerUnityEvent on_ticktack = new TimerUnityEvent();

    public int sec = 0;

    // Start is called before the first frame update
    void Start() {
        on_start.Invoke();
        StartCoroutine(timer(sec));
    }

    private IEnumerator timer(int s) {
        float time_goes_by = 0;
        while (time_goes_by <= s) {
            on_ticktack.Invoke(time_goes_by);
            time_goes_by += Time.deltaTime;
            yield return null;
        }
        on_finish.Invoke();
    }

    public void reset() {
        StopAllCoroutines();
        StartCoroutine(timer(sec));
    }
}