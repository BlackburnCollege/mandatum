using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mandatum {
    public class GameScript : MonoBehaviour {


        public int XSize = 32;
        public int ZSize = 16;
        private Transform[,] occupiedSquares;
        private Unit[,] units;
        private Transform props;

        public Transform[] redTeamUnits = new Transform[3];
        public Transform[] blueTeamUnits = new Transform[3];

        private double timeClock = 0;
        private int currentTurn = 0;
        private bool playerTurn = true;
        private readonly float boardHeight = .05f;

        Vector3 GetWorldPointOnGrid(int x, int z) {
            float xPos = (x / ((float)XSize - 1f)) * (2f) - 1f;
            float zPos = (z / ((float)ZSize - 1f)) * (2f) - 1f;
            return gameObject.transform.TransformPoint(xPos, boardHeight, zPos);
        }

        // Use this for initialization
        void Start() {
            occupiedSquares = new Transform[XSize, ZSize];
            props = gameObject.transform.Find("Props");
            var xTest = (1f / ((XSize - 1f) / 2f));
            var zTest = (1f / ((ZSize - 1f) / 2f));
            Bounds bounds = GetComponent<Renderer>().bounds;

            Debug.Log(bounds.extents);
            for (int x = 0; x < XSize; x++) {
                float xPos = (x / ((float)XSize - 1f)) * (2f) - 1f;
                for (int z = 0; z < ZSize; z++) {
                    float zPos = (z / ((float)ZSize - 1f)) * (2f) - 1f;
                    Vector3 position2 = new Vector3(bounds.center.x + (bounds.extents.x * xPos), bounds.center.y + boardHeight, bounds.center.z + (bounds.extents.z * zPos));
                    foreach (Transform item in props.transform) {
                        Renderer render = item.GetComponent<Renderer>();
                        bool hit = Vector3.Distance(render.bounds.ClosestPoint(position2), position2) <= (xTest * bounds.extents.x / 3f) + (zTest * bounds.extents.z / 3f);
                        if (hit) {
                            occupiedSquares[x, z] = item;
                            break;
                        }
                    }
                    // DEBUG draw grid
                    /*
                    //Debug.Log("xPos: " + xPos);
                    //Debug.Log("zPos: " + zPos);
                    float bx = bounds.extents.x * ((xPos + xTest) / 2);
                    float bz = bounds.extents.z * ((zPos + zTest) / 2);
                    //float ox = bounds.extents.x * xTest;
                    //float oz = bounds.extents.z * zTest;
                    //bx = bx + ox;
                    //bz = bz + oz;
                    Vector3 topLeft = new Vector3(bounds.center.x - bx, bounds.center.y + bounds.extents.y, bounds.center.z + bz);
                    Vector3 bottomLeft = new Vector3(bounds.center.x - bx, bounds.center.y + bounds.extents.y, bounds.center.z - bz);
                    Vector3 bottomRight = new Vector3(bounds.center.x + bx, bounds.center.y + bounds.extents.y, bounds.center.z - bz);
                    //Debug.Log(topLeft + " " + topRight + " " + bottomLeft + " " + bottomRight);
                    //var topLeft = gameObject.transform.TransformPoint((xPos - xTest) * bx, boardHeight, (zPos - zTest) * bz);
                    //var topRight = gameObject.transform.TransformPoint((xPos + xTest) * bx, boardHeight, (zPos - zTest) * bz);
                    //var bottomLeft = gameObject.transform.TransformPoint((xPos - xTest) * bx, boardHeight, (zPos + zTest) * bz);
                    //var bottomRight = gameObject.transform.TransformPoint((xPos + xTest) * bx, boardHeight, (zPos + zTest) * bz);

                    Color color = occupiedSquares[x, z] == null ? Color.white : Color.red;
                    //Debug.DrawLine(position2, position2 + new Vector3(0, 1, 0), color, 100f, false); // collision detected

                    //Debug.DrawLine(topLeft, topRight, Color.white, 100f, false); // top
                    //Debug.DrawLine(topRight, bottomRight, Color.white, 100f, false); // right
                    //Debug.DrawLine(bottomRight, bottomLeft, Color.white, 100f, false); // bottom
                    //Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f, false); // bottom
                    */

                }
            }

            // debug bounds
            /*
            Vector3 bTopLeft = new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y, bounds.center.z - bounds.extents.z);
            Vector3 bTopRight = new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y, bounds.center.z + bounds.extents.z);
            Vector3 bBottomLeft = new Vector3(bounds.center.x - bounds.extents.x, bounds.center.y, bounds.center.z - bounds.extents.z);
            Vector3 bBottomRight = new Vector3(bounds.center.x - bounds.extents.x, bounds.center.y, bounds.center.z + bounds.extents.z);

            Color bColor = Color.blue;
            Debug.DrawLine(bTopLeft, bTopRight, bColor, 100f, false); // top
            Debug.DrawLine(bTopRight, bBottomRight, bColor, 100f, false); // right
            Debug.DrawLine(bBottomRight, bBottomLeft, bColor, 100f, false); // bottom
            Debug.DrawLine(bBottomLeft, bTopLeft, bColor, 100f, false); // bottom
            */


            // add units


        }

        // Update is called once per frame
        void Update() {

        }
    }
}