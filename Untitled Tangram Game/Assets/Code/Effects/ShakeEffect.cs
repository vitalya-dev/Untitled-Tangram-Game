using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour {

    public void shake(float duration) {
        StartCoroutine(__shake(duration, .1f));
    }

    private IEnumerator __shake(float duration, float magnitude) {
        Vector3 original_pos = transform.localPosition;
        /* ========================================== */
        float elapsed = 0.0f;
        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = original_pos + new Vector3(x, y, 0);
            /* ========================================== */
            elapsed += Time.deltaTime;
            /* ========================================== */
            yield return null;
        }
        /* ========================================== */
        transform.localPosition = original_pos;
    }
}