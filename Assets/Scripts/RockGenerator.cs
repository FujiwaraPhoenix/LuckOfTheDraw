using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour {
    public GameObject RockPreFab1;
    public GameObject RockPreFab2;
    public GameObject RockPreFab3;
    //GameObject generatedFruit;
    int RockGenNumber;

    public GameObject Rock01;
    public GameObject Rock02;
    public GameObject Rock03;
    public GameObject Rock04;
    public GameObject Rock05;

    //int HealingAmount;
    //int HungerSaturation;
    //float SpeedAlteration;
    //int Armor;
    //float RegenLevel;

    public GameObject[] RockList = new GameObject[5];
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            //HealingAmount = Random.Range(-5, 10);
            //HungerSaturation = Random.Range(-5, 10);
            //SpeedAlteration = Random.Range(-10f, 20f);
            //Armor = Random.Range(0, 5);
            //RegenLevel = Random.Range(0f, 1f);
            RockGenNumber = Random.Range(0, 3);
            if (RockGenNumber == 0)
            {
                GameObject generatedRock = Instantiate(RockPreFab1, transform.position, transform.rotation);
                //generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                //generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                //generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                //generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                //generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                //generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                RockList[i] = generatedRock;
            }
            if (RockGenNumber == 1)
            {
                GameObject generatedRock = Instantiate(RockPreFab2, transform.position, transform.rotation);
                //generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                //generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                //generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                //generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                //generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                //generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                RockList[i] = generatedRock;
            }
            if (RockGenNumber == 2)
            {
                GameObject generatedRock = Instantiate(RockPreFab3, transform.position, transform.rotation);
                //generatedFruit.GetComponent<FruitProperties>().HealthAmount = HealingAmount;
                //generatedFruit.GetComponent<FruitProperties>().HungerAmount = HungerSaturation;
                //generatedFruit.GetComponent<FruitProperties>().SpeedPropety = SpeedAlteration;
                //generatedFruit.GetComponent<FruitProperties>().ArmorProperty = Armor;
                //generatedFruit.GetComponent<FruitProperties>().Regenproperty = RegenLevel;
                //generatedFruit.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
                RockList[i] = generatedRock;
            }
        }
        Rock01 = RockList[0];
        Rock02 = RockList[1];
        Rock03 = RockList[2];
        Rock04 = RockList[3];
        Rock05 = RockList[4];
        Debug.Log(RockList[0]);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
