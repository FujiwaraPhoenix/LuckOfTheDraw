using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProperties : MonoBehaviour {
    public int RockGenNumber;
	// Use this for initialization
	void Start () {
        RockGenNumber = Random.Range(1,6);
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Resource>().modifierNum = RockGenNumber;
	}
}
