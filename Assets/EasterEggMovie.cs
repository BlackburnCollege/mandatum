using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(Plane))]
[RequireComponent(typeof(MeshRenderer))]
public class EasterEggMovie : MonoBehaviour {

    VideoPlayer player;
    Plane plane;
    public Transform character;
    //Material meshMaterial;

    int alpha = 0x00;
	// Use this for initialization
	void Start () {
		player = GetComponent<VideoPlayer>();
        plane = GetComponent<Plane>();
        character = GetComponent<Transform>();
        //meshMaterial = GetComponent<MeshRenderer>().material;
    }


	
	// Update is called once per frame
	void Update () {
        if (player.isPlaying) {
            if (alpha < 60) {
                alpha = (alpha + 1);
            }
            var material = GetComponent<Renderer>().material;
            var color = material.color;
            var newColor = new Color(color.r, color.g, color.b, Mathf.Clamp(((float) alpha) / 60.0f, 0.0f, 1.0f));
            material.color = newColor;
        } else {
            var distance = plane.GetDistanceToPoint(character.position);
            var input = Input.GetKey(KeyCode.R);
            Debug.Log(input);
            if (input) {
                Debug.Log(distance);
                if (distance >= 0 && distance <= 5) {
                    player.isLooping = true;
                    player.Play();

                }
            }
        }
        
	}
}
