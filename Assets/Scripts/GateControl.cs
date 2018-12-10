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

    public GameObject bossPrefab; //The prefab for instantiating the boss

    public TestCameraZoom cam; //What you call to activateZoom. Replace this with the actual camera script.

    private GameObject leftblack;
    private GameObject rightblack;
    private GameObject topblack;
    private GameObject bottomblack;
    private Color alphaColor;
    private float SpeedOfFade = 2.0f;
    private bool isentered = false;
    public AudioSource mainmusic;

    bool closeGate = false;
    
	void Start () {

        leftblack = GameObject.Find("LeftBossShadow");
        rightblack = GameObject.Find("rightBossShadow");
        topblack = GameObject.Find("topBossShadow");
        bottomblack = GameObject.Find("bottomBossShadow");
        alphaColor = leftblack.GetComponent<SpriteRenderer>().color;
        alphaColor.a = 1;
       
        for (int x = 0; x < gate.Length; x++)
        {
            gate[x].SetActive(false);
        }
	}
	
	void Update () {
        if (isentered == true)
        {
            mainmusic.mute = true;
            leftblack.GetComponent<SpriteRenderer>().color = Color.Lerp(leftblack.GetComponent<SpriteRenderer>().color, alphaColor, SpeedOfFade * Time.deltaTime);
            rightblack.GetComponent<SpriteRenderer>().color = Color.Lerp(rightblack.GetComponent<SpriteRenderer>().color, alphaColor, SpeedOfFade * Time.deltaTime);
            topblack.GetComponent<SpriteRenderer>().color = Color.Lerp(topblack.GetComponent<SpriteRenderer>().color, alphaColor, SpeedOfFade * Time.deltaTime);
            bottomblack.GetComponent<SpriteRenderer>().color = Color.Lerp(bottomblack.GetComponent<SpriteRenderer>().color, alphaColor, SpeedOfFade * Time.deltaTime);
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!closeGate && collision.tag == "Player")
        {

            isentered = true;
            closeGate = true;
            for (int x = 0; x < gate.Length; x++)
            {
                gate[x].SetActive(true);
            }

            

            if (zoom)
            {
                cam.activateZoom(cameraPos, zoomAmount, zoomSpeed);
                
            }

            Instantiate(bossPrefab, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, -1), Quaternion.identity);
        }
    }
}
