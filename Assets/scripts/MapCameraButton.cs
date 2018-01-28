using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



namespace UnityStandardAssets.Characters.FirstPerson {
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
                    Rigidbody character = MandatumFPSController.character;
                    Debug.Log("distance from player to " + otherCamera + ": " + Mathf.Abs(Vector3.Distance(character.transform.position, renderer.transform.position)));
                    if (renderer.isVisible && Mathf.Abs(Vector3.Distance(character.transform.position, renderer.transform.position)) <= distance) {
                        Debug.Log("Setting camera for " + otherCamera);
                        if (!MandatumFPSController.characterController.OnMainCam) {
                            MandatumFPSController.characterController.SetOtherCamera(null);
                            MandatumFPSController.characterController.OnMainCam = true;
                        } else {
                            MandatumFPSController.characterController.SetOtherCamera(otherCamera);
                            MandatumFPSController.characterController.OnMainCam = false;
                        }
                        cooldown = 10;
                    } else {
                        if (!MandatumFPSController.characterController.OnMainCam && MandatumFPSController.characterController.OtherCam == otherCamera) {
                            MandatumFPSController.characterController.SetOtherCamera(null);
                            MandatumFPSController.characterController.OnMainCam = true;
                        }
                    }
                }
            } else {
                cooldown = Mathf.Clamp(cooldown - 1, 0, 10);
            }
        }
    }
}