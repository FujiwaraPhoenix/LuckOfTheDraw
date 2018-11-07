using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectOverTime : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += 1f * Time.deltaTime;
        if(timer > 1f)
        {
            Destroy(this.gameObject);
        }	
	}
}
