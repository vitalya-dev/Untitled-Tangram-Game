using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {
    public Sprite animal_is_done;

    void Start() {
        if (PlayerPrefs.GetString("Reaper", "In Process") == "Is Done")
            GetComponent<Image>().sprite = animal_is_done;
    }
}