using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {


    public int XSize = 32;
    public int ZSize = 16;
    private GameObject[,] occupiedSquares;
    private Transform props;

	// Use this for initialization
	void Start () {
        occupiedSquares = new GameObject[XSize, ZSize];
        props = gameObject.transform.Find("Props");
        for (int x = 0; x < XSize; x++) {
            int xPos = x - (XSize / 2);
            for (int z = 0; z < ZSize; z++) {
                int zPos = z - (ZSize / 2);
                Vector3 position = new Vector3(xPos, 0.2f, zPos);
                foreach (GameObject item in props.transform) {
                    Renderer render = item.GetComponent<Renderer>();
                    if (render.bounds.Contains(position)) {
                        occupiedSquares[x, z] = item;
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
