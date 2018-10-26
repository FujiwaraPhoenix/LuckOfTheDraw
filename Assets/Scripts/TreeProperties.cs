using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeProperties : MonoBehaviour {
    private float fruitRichness;
    public GameObject FruitGenerator;
    public GameObject Fruit;
    private int FruitNumber;
    Vector3 spawnPos;
    public Sprite trunk01;
    public Sprite trunk02;
    public Sprite trunk03;

    float trunkNumber;
    // Use this for initialization
    void Start () {
        fruitRichness = Random.Range(1, 5);
        trunkNumber = Random.Range(0f, 3f);
        FruitNumber = Random.Range(0, 5);

        if(trunkNumber >= 0f && trunkNumber < 1f)
        {
            GetComponent<SpriteRenderer>().sprite = trunk01;
        }
        if (trunkNumber >= 1f && trunkNumber < 2f)
        {
            GetComponent<SpriteRenderer>().sprite = trunk02;
        }
        if (trunkNumber >= 2f && trunkNumber < 3f)
        {
            GetComponent<SpriteRenderer>().sprite = trunk03;
        }
        Fruit = FruitGenerator.GetComponent<FruitSpeciesGenerator>().FruitList[FruitNumber].gameObject;
        for (int i = 0; i < fruitRichness;i++)
        {
            spawnPos = new Vector3(Random.Range(-1.65f, 1.65f), Random.Range(0, 2.05f), -2);
            GameObject consumable = (GameObject)Instantiate(Fruit, transform.position, Quaternion.identity);
            consumable.transform.SetParent(this.transform);
            consumable.transform.localPosition = spawnPos;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
