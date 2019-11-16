using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sentence {
    [TextArea]
    public string message;
    public Sprite avatar;
}

public class DialogueManager : MonoBehaviour {
    public Canvas ui;
    public Vector2 start_position;
    public GameObject message_prefab;
    public Sentence[] sentences;

    IEnumerator Start() {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < sentences.Length; i++) {
            Text text_ui = Instantiate(message_prefab, Vector3.zero, Quaternion.identity, ui.transform).GetComponent<Text>();
            text_ui.text = sentences[i].message;
            text_ui.rectTransform.localPosition = new Vector3(
                start_position.x,
                start_position.y - text_ui.rectTransform.rect.height * i,
                0
            );
            text_ui.transform.Find("Avatar").GetComponent<Image>().sprite = sentences[i].avatar;
            text_ui.transform.Find("Avatar").GetComponent<Image>().SetNativeSize();
            yield return new WaitForSeconds(1.0f);
        }
    }

}