using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public void start_rave() {
         SceneManager.LoadSceneAsync(1);
    }
}