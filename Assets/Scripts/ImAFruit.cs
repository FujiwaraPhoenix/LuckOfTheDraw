using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImAFruit : MonoBehaviour {

    public static bool moving = false;
    public GameObject player;
    public float fruitspeed = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //float step = fruitspeed * Time.deltaTime;
        //if (moving == true)
        //{
        //    Vector3.MoveTowards(transform.position, player.transform.position, step);
        //}
    }
}
