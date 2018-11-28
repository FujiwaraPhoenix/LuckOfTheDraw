using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitProperties : MonoBehaviour {
    public int HealthAmount;
    public int HungerAmount;
    public float SpeedPropety;
    public int ArmorProperty;
    public float Regenproperty;

	// Use this for initialization
	void Start () {

    

    }
	
	// Update is called once per frame
	void Update () {
        if(this.transform.parent == null)
        {
            Destroy(this.gameObject);
        }

    }
}
