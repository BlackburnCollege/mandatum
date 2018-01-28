using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParticleSystem system = gameObject.GetComponentInChildren<ParticleSystem>();
        system.Play(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
