using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Data {
    public string name;
    public string value;
}

public class GameData : MonoBehaviour {
    public Data[] datas;

    void Start() {
        foreach (var data in datas) {
            PlayerPrefs.SetString(data.name, data.value);
        }
    }
}