using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitProperties : MonoBehaviour {
    public int HealthAmount;
    public static int publicHealth;
    public int HungerAmount;
    public static int publicHunger;
    public float SpeedPropety;
    public static float publicSpeed;
    public int ArmorProperty;
    public static int publicArmor;
    public float Regenproperty;
    public static float publicRegen;

	// Use this for initialization
	void Start () {

    

    }
	
	// Update is called once per frame
	void Update () {
        publicHealth = HealthAmount;
        publicHunger = HungerAmount;
        publicArmor = ArmorProperty;
        publicSpeed = SpeedPropety;
        publicRegen = Regenproperty;


    }
}
