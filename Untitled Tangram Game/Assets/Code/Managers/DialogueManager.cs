using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Sentence {
    [TextArea]
    public string text;
    public Sprite avatar;
}

public class DialogueManager : MonoBehaviour {
    public Canvas ui;
    public GameObject sentence_go;

    public float delay;

    public Vector2 position;

    public Sentence[] sentences;

    public UnityEvent on_finish;

    IEnumerator Start() {
        yield return new WaitForSeconds(delay);

        List<Text> sentence_ui_list = new List<Text>();
        for (int i = 0; i < sentences.Length; i++) {
            /* ==================================================== */
            Text sentence_ui = Instantiate(sentence_go, Vector3.zero, Quaternion.identity, ui.transform).GetComponent<Text>();
            sentence_ui.rectTransform.localPosition = new Vector3(
                position.x,
                position.y - sentence_ui.rectTransform.rect.height * i,
                0
            );
            sentence_ui.transform.Find("Avatar").GetComponent<Image>().sprite = sentences[i].avatar;
            sentence_ui.transform.Find("Avatar").GetComponent<Image>().SetNativeSize();
            sentence_ui_list.Add(sentence_ui);
            yield return new WaitForSeconds(delay);
            /* ==================================================== */
            foreach (var letter in sentences[i].text) {
                sentence_ui.text += letter;
                if (letter == '.' && sentence_ui.text.Length < sentences[i].text.Trim().Length)
                    yield return new WaitForSeconds(delay);
                else
                    yield return null;
            }
            yield return new WaitForSeconds(delay);
            /* ==================================================== */
        }
        on_finish.Invoke();
        /* ==================================================== */
        foreach (var sentence_ui in sentence_ui_list) {
            Destroy(sentence_ui.gameObject, 2f);
        }
        /* ==================================================== */
    }
}