using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(MeshRenderer))]

public class EasterEggMovie : MonoBehaviour {

    VideoPlayer player;
    public Transform character;

    int playTimer = 0;
    //Material meshMaterial;

    int alpha = 0x00;
    // Use this for initialization
    void Start() {
        player = GetComponent<VideoPlayer>();

        character = GetComponent<Transform>();
        //meshMaterial = GetComponent<MeshRenderer>().material;
    }



    // Update is called once per frame
    void Update() {
        if (player.isPlaying) {
            if (alpha < 60) {
                alpha = (alpha + 1);
            }
            var material = GetComponent<Renderer>().material;
            var color = material.color;
            var newColor = new Color(color.r, color.g, color.b, Mathf.Clamp(((float)alpha) / 60.0f, 0.0f, 1.0f));
            material.color = newColor;
            if (Input.GetKey(KeyCode.R)) {
                player.Stop();
                alpha = 0;
                material = GetComponent<Renderer>().material;
                color = material.color;
                newColor = new Color(color.r, color.g, color.b, Mathf.Clamp(((float)alpha) / 60.0f, 0.0f, 1.0f));
                material.color = newColor;
                playTimer = 10;
            }
        } else {
            playTimer = Mathf.Clamp(playTimer - 1, 0, 10);
            var distance = Vector3.Distance(gameObject.transform.position, character.position);
            var input = Input.GetKey(KeyCode.R);

            if (input && playTimer == 0) {

                if (distance <= 5) {
                    player.isLooping = true;
                    player.Play();

                }
            }
        }

    }
}
