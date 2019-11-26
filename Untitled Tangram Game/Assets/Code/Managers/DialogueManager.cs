using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public Canvas ui;
    public GameObject sentence_go;

    public AudioSource voice;

    public float delay;

    public Vector2 position;

    public Sentence[] sentences;

    public UnityEvent on_finish;

    IEnumerator Start() {
        yield return new WaitForSeconds(delay);

        List<Image> sentence_ui_list = new List<Image>();
        for (int i = 0; i < sentences.Length; i++) {
            /* ==================================================== */
            Image sentence_ui = Instantiate(sentence_go, Vector3.zero, Quaternion.identity, ui.transform).GetComponent<Image>();
            sentence_ui.rectTransform.localPosition = new Vector3(
                position.x,
                position.y - (sentence_ui.rectTransform.rect.height + 5) * i,
                0
            );
            sentence_ui_list.Add(sentence_ui);
            sentence_ui.transform.Find("Avatar").GetComponent<Image>().sprite = sentences[i].avatar;
            sentence_ui.transform.Find("Avatar").GetComponent<Image>().SetNativeSize();
            yield return new WaitForSeconds(delay);
            /* ==================================================== */
            Text text_ui = sentence_ui.transform.Find("Text").GetComponent<Text>();
            foreach (var letter in sentences[i].text) {
                /* ==================================== */
                if (!voice.isPlaying) {
                    voice.PlayOneShot(sentences[i].voice);
                    voice.clip = sentences[i].voice;
                }
                /* ==================================== */
                text_ui.text += letter;
                if (letter == '.' && text_ui.text.Length < sentences[i].text.Trim().Length)
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