using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Sentence {
    [TextArea]
    public string letters;
    public Sprite avatar;
}

public class DialogueManager : MonoBehaviour {
    public Canvas ui;
    public GameObject message_go;
    
    public Vector2 start_position;
    public UnityEvent on_finish;
    public Sentence[] sentences;

    IEnumerator Start() {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < sentences.Length; i++) {
            Text message_ui = Instantiate(message_go, Vector3.zero, Quaternion.identity, ui.transform).GetComponent<Text>();
            message_ui.text = sentences[i].letters;
            message_ui.rectTransform.localPosition = new Vector3(
                start_position.x,
                start_position.y - message_ui.rectTransform.rect.height * i,
                0
            );
            message_ui.transform.Find("Avatar").GetComponent<Image>().sprite = sentences[i].avatar;
            message_ui.transform.Find("Avatar").GetComponent<Image>().SetNativeSize();
            yield return new WaitForSeconds(1.0f);
        }
        on_finish.Invoke();
    }

}