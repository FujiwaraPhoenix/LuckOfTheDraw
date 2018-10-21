using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeProperties : MonoBehaviour {
    private float fruitRichness;
    public GameObject Fruit;
    Vector3 spawnPos;
	// Use this for initialization
	void Start () {
        fruitRichness = Random.Range(1, 5);
		for(int i = 0; i < fruitRichness;i++)
        {
            spawnPos = new Vector3(Random.Range(-1.65f, 1.65f), Random.Range(0, 2.05f), -1);
            GameObject consumable = (GameObject)Instantiate(Fruit, transform.position, Quaternion.identity);
            consumable.transform.SetParent(this.transform);
            consumable.transform.localPosition = spawnPos;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
