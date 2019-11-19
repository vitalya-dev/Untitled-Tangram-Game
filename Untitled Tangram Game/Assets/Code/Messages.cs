using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Messages : MonoBehaviour {
    public Canvas ui;
    public GameObject sentence_go;

    public float delay;

    public Vector2 position;

    public Sentence[] success_sentences;
    public Sentence[] failed_sentences;

    void Start() {
        if (GlobalVariables.last_shot == "Fail")
            StartCoroutine(display_sentence(failed_sentences[Random.Range(0, failed_sentences.Length)]));
        else if (GlobalVariables.last_shot == "Success")
            StartCoroutine(display_sentence(success_sentences[Random.Range(0, success_sentences.Length)]));
    }

    private IEnumerator display_sentence(Sentence sentence) {
        yield return new WaitForSeconds(delay);

        /* ==================================================== */
        Text sentence_ui = Instantiate(sentence_go, Vector3.zero, Quaternion.identity, ui.transform).GetComponent<Text>();
        sentence_ui.rectTransform.localPosition = new Vector3(
            position.x,
            position.y,
            0
        );
        sentence_ui.transform.Find("Avatar").GetComponent<Image>().sprite = sentence.avatar;
        sentence_ui.transform.Find("Avatar").GetComponent<Image>().SetNativeSize();
        yield return new WaitForSeconds(delay);
        /* ==================================================== */
        foreach (var letter in sentence.text) {
            sentence_ui.text += letter;
            if (letter == '.' && sentence_ui.text.Length < sentence.text.Trim().Length)
                yield return new WaitForSeconds(delay);
            else
                yield return null;
        }
        yield return new WaitForSeconds(delay);
        /* ==================================================== */
        Destroy(sentence_ui.gameObject, 2.0f);
    }
}