using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    void Start() {
        transform.Find("Attempts").GetComponent<Text>().text =
            (GlobalVariables.max_attempts - GlobalVariables.attempts).ToString();
    }
}