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

    public Vector2 position;

    public Sentence[] sentences;

    public UnityEvent on_finish;

    IEnumerator Start() {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < sentences.Length; i++) {
            Text sentence_ui = Instantiate(sentence_go, Vector3.zero, Quaternion.identity, ui.transform).GetComponent<Text>();
            sentence_ui.text = sentences[i].text;
            sentence_ui.rectTransform.localPosition = new Vector3(
                position.x,
                position.y - sentence_ui.rectTransform.rect.height * i,
                0
            );
            sentence_ui.transform.Find("Avatar").GetComponent<Image>().sprite = sentences[i].avatar;
            sentence_ui.transform.Find("Avatar").GetComponent<Image>().SetNativeSize();
            yield return new WaitForSeconds(1.0f);
        }
        on_finish.Invoke();
    }

}