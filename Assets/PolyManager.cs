﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyManager : MonoBehaviour {

    public string BiomeType;
    public int number;
    public int size;
    public int proximity;
    public int cluster;
    public int colorfluctuation;
    public Color TheColor;
    public Vector3 TheScale;
    public string stretch;
    private float RandomSize;
   // public GameObject hex;
    public GameObject[] Hexs;
    public GameObject Hex;
	// Use this for initialization
	void Start () {

       
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {


           
            Generate();
            

        }
		
	}


    void Generate() {

        GameObject[] destroys = GameObject.FindGameObjectsWithTag("Hexs");
        foreach(GameObject destroy in destroys)
        {

            GameObject.Destroy(destroy);
        }

        number = Random.Range(1,200);

        for (int i = 0; i < number; i++)
        {
            Instantiate(Hex, new Vector3(Random.Range(0,100),Random.Range(0,100),-1), Quaternion.identity);
        }
        RandomSize = Random.Range(0.2f, 5f);
        TheColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        TheScale = new Vector3(RandomSize, RandomSize, RandomSize);
        Hexs = GameObject.FindGameObjectsWithTag("Hexs");

        foreach(GameObject hex in Hexs)
        {
            hex.GetComponent<SpriteRenderer>().color = TheColor;
            hex.GetComponent<Transform>().localScale = TheScale;
        }
     
           // hex.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
      //  test = new Color(Random.Range(0,255), Random.Range(0,255), Random.Range(0,255), 1);

    }
}
