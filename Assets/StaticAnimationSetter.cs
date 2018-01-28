using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAnimationSetter : MonoBehaviour {

    double randomStart = 0;
    public string animationType;
    public bool valueToSet;
    private bool started = false;
    // Use this for initialization
    void Start() {
        for (int i = 0; i < 10; i++) {
            float v = Random.value;
        }
        randomStart = Random.value * 3;
    }

    // Update is called once per frame
    void Update() {
        if (randomStart <= 0 && !started) {
            (GetComponent<Animator>()).SetBool(animationType, valueToSet);
            started = true;
        } else {
            randomStart -= Time.deltaTime;
        }
    }
}
