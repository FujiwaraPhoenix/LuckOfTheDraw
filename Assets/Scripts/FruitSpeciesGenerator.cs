using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpeciesGenerator : MonoBehaviour {
    public GameObject FruitPreFab1;
    public GameObject FruitPreFab2;
    public GameObject FruitPreFab3;
    //GameObject generatedFruit;
    int fruitGenNumber;


    public GameObject Fruit01;
    public GameObject Fruit02;
    public GameObject Fruit03;
    public GameObject Fruit04;
    public GameObject Fruit05;

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
            SpeedAlteration = Random.Range(-0.1f, 2f);
            Armor = Random.Range(0, 5);
            RegenLevel = Random.Range(0f, 1f);
            fruitGenNumber = Random.Range(0, 3);
            if (fruitGenNumber == 0)
            {
                GameObject generatedFruit = Instantiate(FruitPreFab1, transform.position, transform.rotation);
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
                GameObject generatedFruit = Instantiate(FruitPreFab2, transform.position, transform.rotation);
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
                GameObject generatedFruit = Instantiate(FruitPreFab3, transform.position, transform.rotation);
                generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                FruitList[i] = generatedFruit;
            }
        }
        Fruit01 = FruitList[0];
        Fruit02 = FruitList[1];
        Fruit03 = FruitList[2];
        Fruit04 = FruitList[3];
        Fruit05 = FruitList[4];
    }

    // Update is called once per frame
    void Update () {
    }
}
