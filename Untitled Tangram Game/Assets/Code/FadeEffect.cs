using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeEffect : MonoBehaviour {
    public float duration = 5;

    public UnityEvent on_fade;

    private bool interrupted;
    IEnumerator Start() {
        /* ==================================================== */
        interrupted = false;
        /* ==================================================== */
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        /* ==================================================== */
        Color a = renderer.color;
        Color b = new Color(a.r, a.g, a.b, 0);

        float elapsed_time = 0;
        do {
            elapsed_time += Time.deltaTime;
            renderer.color = Color.Lerp(a, b, elapsed_time / duration);
            yield return null;
        } while (elapsed_time / duration < 1 && !interrupted);
        /* ==================================================== */
        renderer.color = b;
        on_fade.Invoke();
        gameObject.SetActive(false);
    }

    public void interrupt() {
        interrupted = true;
    }
}