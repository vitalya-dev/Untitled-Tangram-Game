using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : MonoBehaviour {
    public ParticleSystem lightning_prefab;
    private ParticleSystem lightning;

    void Start() {
         lightning = Instantiate(lightning_prefab, transform.position, Quaternion.identity, transform);
         lightning.transform.Translate(0, 0, -5, Space.World);
         if (GetComponent<Selectable>())
            GetComponent<Selectable>().on_select.AddListener((Selectable s, Vector2 v) => play());
    }

    public void play() {
        lightning.Play();
    }
}