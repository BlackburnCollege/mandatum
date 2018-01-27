using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



namespace UnityStandardAssets.Characters.FirstPerson {
    [RequireComponent(typeof(Collider))]
    public class MapCameraButton : MonoBehaviour {

        public KeyCode hitKey;
        public float Distance { get; set; }
        private int cooldown = 0;
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (cooldown == 0) {
                if (Input.GetKeyDown(hitKey)) {
                    var ray = Camera.main.ScreenPointToRay(CrossPlatformInputManager.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Distance)) {
                        if (hit.collider.gameObject == gameObject) {
                            MandatumFPSController.characterController.OnMainCam = !MandatumFPSController.characterController.OnMainCam;
                            cooldown = 10;
                        }
                    }

                }
            } else {
                cooldown = Mathf.Clamp(cooldown - 1, 0, 10);
            }
        }
    }
}