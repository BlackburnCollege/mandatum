using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



namespace UnityStandardAssets.Characters.FirstPerson {
    [RequireComponent(typeof(Collider))]
    public class RadioControl : MonoBehaviour {

        public KeyCode hitKey;
        public float distance = 5f;
        private int cooldown = 0;
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (cooldown == 0) {
                if (Input.GetKeyDown(hitKey)) {
                    Renderer renderer = GetComponent<Renderer>();
                    if (renderer.isVisible && Vector3.Distance(MandatumFPSController.character.transform.position, renderer.transform.position) <= distance) {
                        MandatumFPSController.characterController.OnMainCam = !MandatumFPSController.characterController.OnMainCam;
                        cooldown = 10;
                    } else {
                        
                    }
                }
            } else {
                cooldown = Mathf.Clamp(cooldown - 1, 0, 10);
            }
        }
    }
}