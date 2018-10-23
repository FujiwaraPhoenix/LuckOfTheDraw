using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    //This is attached to the player; we parse all information from the InventoryController(ic), so we don't need as many globals here.

    //Gun information. These are all the base stats for the gun, plus modifiers.

    //Rate of Fire
    public float rof = 3f;
    public float rofMod = 0f;

    //Damage
    public int damage = 1;
    public int dmgMod = 0;

    //Accuracy (Spread)
    public float baseSpread = 5f;
    public float spreadMod = 0f;

    //The rest is handled from within the instantiation of each object.s

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
