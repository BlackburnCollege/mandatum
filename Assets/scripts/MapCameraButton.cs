using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



namespace UnityStandardAssets.Characters.FirstPerson {
    [RequireComponent(typeof(Collider))]
    public class MapCameraButton : MonoBehaviour {

        public KeyCode hitKey;
        public float distance = 5f;
        private int cooldown = 0;
        public Camera otherCamera = null;
        // Use this for initialization
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
            if (cooldown == 0) {
                if (Input.GetKeyDown(hitKey)) {
                    Renderer renderer = GetComponent<Renderer>();
                    var character = MandatumFPSController.character;
                    Debug.Log(renderer + " " + character);
                    if (renderer.isVisible && Vector3.Distance(character.transform.position, renderer.transform.position) <= distance) {
                        MandatumFPSController.characterController.SetOtherCamera(otherCamera);
                        MandatumFPSController.characterController.OnMainCam = false;
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