using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace mandatum {


    public class RadioGameScript : MonoBehaviour {

        private class MorseCode {
            public float Position {
                get; set;
            }
            public bool Hit {
                get; set;
            }
        }

        public KeyCode cameraKey;
        public KeyCode hitKey;
        public float distance = 5f;
        private int cooldown = 0;
        public Camera otherCamera = null;
        public Transform props;
        public Transform uiCanvas;
        public RectTransform morseLongPrefab;
        public RectTransform morseShortPrefab;
        public Text interactText;
        public RawImage morseHitLine;
        private bool gameStarted;
        private bool keyDown = false;
        private ArrayList morseCodes = new ArrayList();
        private AudioSource sound;

        private Transform morseUnhit;
        private Transform morseHit;

        // Use this for initialization
        void Start() {

            sound = GetComponent<AudioSource>();
            morseUnhit = gameObject.transform.Find("Morse");
            morseHit = gameObject.transform.Find("MorseClicked");
        }

        private void setupGame() {
            morseHitLine.gameObject.SetActive(true);


        }

        private void updateCamControls() {
            if (cooldown == 0 && !gameStarted) {
                if (Input.GetKeyDown(cameraKey)) {
                    foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) {
                        Rigidbody character = MandatumFPSController.character;
                        if (renderer.isVisible && Mathf.Abs(Vector3.Distance(character.transform.position, renderer.transform.position)) <= distance) {
                            MandatumFPSController.characterController.SetOtherCamera(otherCamera);
                            MandatumFPSController.characterController.OnMainCam = false;
                            cooldown = 10;
                            gameStarted = true;
                            return;
                        }
                    }
                }
            }
        }

        // Update is called once per frame
        void Update() {
            updateCamControls();
            if (gameStarted) {
                bool keyIsDown = Input.GetKey(hitKey);
                if (keyIsDown && !keyDown) {
                    keyDown = true;
                    sound.Play();
                    morseUnhit.gameObject.SetActive(false);
                    morseHit.gameObject.SetActive(true);
                } else if (!keyIsDown && keyDown) {
                    keyDown = false;
                    sound.Stop();
                    morseUnhit.gameObject.SetActive(true);
                    morseHit.gameObject.SetActive(false);
                }
            }

        }
    }
}