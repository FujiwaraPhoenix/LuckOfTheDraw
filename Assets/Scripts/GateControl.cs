using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour {

    //Used for a gate that closes after the player walks through the trigger. Player must be tagged as Player for this to work.

    public GameObject[] gate; //The gameobject that acts as a gate.

    public GameObject cameraPos; //Where you want the camera to zoom to if you want that to happen.
    public bool zoom; //If you want the camera to zoom when the gate closes.
    public float zoomAmount; //How far the camera should zoom
    public float zoomSpeed; //How fast the camera should zoom

    public TestCameraZoom cam; //What you call to activateZoom. Replace this with the actual camera script.

    bool closeGate = false;
    
	void Start () {
        for(int x = 0; x < gate.Length; x++)
        {
            gate[x].SetActive(false);
        }
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!closeGate && collision.tag == "Player")
        {
            closeGate = true;
            for (int x = 0; x < gate.Length; x++)
            {
                gate[x].SetActive(true);
            }
            
            if(zoom)
            {
                cam.activateZoom(cameraPos, zoomAmount, zoomSpeed);
            }
        }
    }
}
