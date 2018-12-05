using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProperties : MonoBehaviour {
    public int GunGenNumber;
    public int ShotGenNumber;
    public int EffectGenNumber;
	// Use this for initialization
	void Start () {
        //Update to reflect different rarieties of items
        /* 
         * Gun
         * Tier 1 (5-6)
         * Multi-shot
         * Lifesteal
         * Tier 2 (3-4)
         * Damage
         * Spread
         * Tier 3 (1-2)
         * Fire Rate
         * Accuracy
         * 
         * 
         * 
         */
        GunGenNumber = Random.Range(1,7);
        ShotGenNumber = Random.Range(1, 7);
        EffectGenNumber = Random.Range(1, 7);

        this.gameObject.GetComponent<Resource>().gunModifier = GunGenNumber;
        this.gameObject.GetComponent<Resource>().shotModifier = ShotGenNumber;
        this.gameObject.GetComponent<Resource>().effectModifier = EffectGenNumber;

        GetComponent<Resource>().colorCode();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}