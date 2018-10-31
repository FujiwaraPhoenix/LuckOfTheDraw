using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour {
    public GameObject RockPreFab1;
    public GameObject RockPreFab2;
    public GameObject RockPreFab3;
    //GameObject generatedFruit;
    int fruitGenNumber;


    public GameObject Rock01;
    public GameObject Rock02;
    public GameObject Rock03;
    public GameObject Rock04;
    public GameObject Rock05;

    int HealingAmount;
    int HungerSaturation;
    float SpeedAlteration;
    int Armor;
    float RegenLevel;

    public GameObject[] FruitList = new GameObject[5];
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            HealingAmount = Random.Range(-5, 10);
            HungerSaturation = Random.Range(-5, 10);
            SpeedAlteration = Random.Range(-10f, 20f);
            Armor = Random.Range(0, 5);
            RegenLevel = Random.Range(0f, 1f);
            fruitGenNumber = Random.Range(0, 3);
            if (fruitGenNumber == 0)
            {
                GameObject generatedFruit = Instantiate(RockPreFab1, transform.position, transform.rotation);
                generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                FruitList[i] = generatedFruit;
            }
            if (fruitGenNumber == 1)
            {
                GameObject generatedFruit = Instantiate(RockPreFab2, transform.position, transform.rotation);
                generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                FruitList[i] = generatedFruit;
            }
            if (fruitGenNumber == 2)
            {
                GameObject generatedFruit = Instantiate(RockPreFab3, transform.position, transform.rotation);
                generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                FruitList[i] = generatedFruit;
            }
        }
        Rock01 = FruitList[0];
        Rock02 = FruitList[1];
        Rock03 = FruitList[2];
        Rock04 = FruitList[3];
        Rock05 = FruitList[4];
    }

    // Update is called once per frame
    void Update()
    {
    }
}
