using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public Vector3 travelDir;
    public bool isSine = false;
    public int aftereffect = 0;
    public int mvtSpd;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += travelDir * mvtSpd * Time.deltaTime;
	}
}
