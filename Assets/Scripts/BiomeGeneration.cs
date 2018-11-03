using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGeneration : MonoBehaviour {
    //these gameobjects will be the specific prefabs for the objects that will exist within the world(e.g trees, boulders, ponds, etc.)
    public Sprite desert;
    public Sprite grassland;
    public Sprite iceTundra;

    public GameObject desertTerrainAsset1;
    public GameObject grassTerrainAsset1;
    public GameObject iceTerrainAsset1;

    public GameObject rock01;
    public GameObject rock02;
    public GameObject rock03;
    int rockGenNumber;

    public GameObject FruitGen;
    public GameObject RockGen;
    int RockNumber;

    //Temporary measure for enemy generation
    public GameObject wanderer;
    public GameObject territorial;
    public GameObject pursuer;
    public GameObject sniper;
    public GameObject spawner;
    public GameObject bullrush;
    public int primaryEnemyNumber = 8;
    public int secondaryEnemyNumber = 5;

    //these floats will determine how many of each asset will populate the world upon the creation of the individual biome
    public float amountOfAsset1;
    public static int asset1Richness;
    float asset1Concentration;
    public float amountOfAsset2;
    public static int asset2Richness;
    float asset2Concentration;

    Vector3 spawnPosition;

    bool isDesert = false;
    bool isGrass = false;
    bool isIce = false;

    float biomeNumber;

    // Use this for initialization
    void Start () {
        biomeNumber = Random.Range(0f, 3f);
        //this will ensure that the biome has a randomly picked color upon activation
        if (biomeNumber >= 0 && biomeNumber < 1f)
        {
            isDesert = true;
            GetComponent<SpriteRenderer>().sprite = desert;
        }
        if (biomeNumber >= 1 && biomeNumber < 2f)
        {
            isGrass = true;
            GetComponent<SpriteRenderer>().sprite = grassland;
        }
        if (biomeNumber >= 2 && biomeNumber < 3f)
        {
            isIce = true;
            GetComponent<SpriteRenderer>().sprite = iceTundra;
        }
        Debug.Log(GetComponent<SpriteRenderer>().sprite);
        //this.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);

        //these for statements will populate the world accordingly with how mnay of a specific asset you want at randomized locations with 
        //randomized size as well.
        if (isDesert)
        {
            for (int i = 0; i < amountOfAsset1; i++)
            {
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Tree = (GameObject)Instantiate(desertTerrainAsset1, transform.position, Quaternion.identity);
                Tree.transform.SetParent(this.transform);
                Tree.transform.localPosition = spawnPosition;
                Tree.GetComponent<TreeProperties>().FruitGenerator = FruitGen;

            }
            for (int i = 0; i < amountOfAsset2; i++)
            {
                //rockGenNumber = Random.Range(0, 3);
                RockNumber = Random.Range(0, 5);
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Rock = (GameObject)Instantiate(RockGen.GetComponent<RockGenerator>().RockList[RockNumber], transform.position, Quaternion.identity);
                Rock.transform.SetParent(this.transform);
                Rock.transform.localPosition = spawnPosition;
                //if (rockGenNumber == 0)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock01, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
                //if (rockGenNumber == 1)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock02, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
                //if (rockGenNumber == 2)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock03, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}

            }
        }
        if (isGrass)
        {
            for (int i = 0; i < amountOfAsset1; i++)
            {
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Tree = (GameObject)Instantiate(grassTerrainAsset1, transform.position, Quaternion.identity);
                Tree.transform.SetParent(this.transform);
                Tree.transform.localPosition = spawnPosition;
                Tree.GetComponent<TreeProperties>().FruitGenerator = FruitGen;

            }
            for (int i = 0; i < amountOfAsset2; i++)
            {
                //rockGenNumber = Random.Range(0, 3);
                RockNumber = Random.Range(0, 5);
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Rock = (GameObject)Instantiate(RockGen.GetComponent<RockGenerator>().RockList[RockNumber], transform.position, Quaternion.identity);
                Rock.transform.SetParent(this.transform);
                Rock.transform.localPosition = spawnPosition;
                //if (rockGenNumber == 0)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock01, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
                //if (rockGenNumber == 1)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock02, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
                //if (rockGenNumber == 2)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock03, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
            }
        }
        if (isIce)
        {
            for (int i = 0; i < amountOfAsset1; i++)
            {
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Tree = (GameObject)Instantiate(iceTerrainAsset1, transform.position, Quaternion.identity);
                Tree.transform.SetParent(this.transform);
                Tree.transform.localPosition = spawnPosition;
                Tree.GetComponent<TreeProperties>().FruitGenerator = FruitGen;

            }
            for (int i = 0; i < amountOfAsset2; i++)
            {
                //rockGenNumber = Random.Range(0, 3);
                RockNumber = Random.Range(0, 5);
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Rock = (GameObject)Instantiate(RockGen.GetComponent<RockGenerator>().RockList[RockNumber], transform.position, Quaternion.identity);
                Rock.transform.SetParent(this.transform);
                Rock.transform.localPosition = spawnPosition;
                //if (rockGenNumber == 0)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock01, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
                //if (rockGenNumber == 1)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock02, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}
                //if (rockGenNumber == 2)
                //{
                //    GameObject Rock = (GameObject)Instantiate(rock03, transform.position, Quaternion.identity);
                //    Rock.transform.SetParent(this.transform);
                //    Rock.transform.localPosition = spawnPosition;
                //}

            }
        }

        //Generating enemies
        enemyGenerate();
        
    }

    // Update is called once per frame
    void Update() { 
    }

    void enemyGenerate() //Chooses two enemies to be the enemy types for that biome, and spawns them similarly to the above resources
    {
        GameObject enemyOne = wanderer;
        GameObject enemyTwo = wanderer;

        switch ((int)Random.Range(0, 6))
        {
            case 0:
                enemyOne = wanderer;
                break;
            case 1:
                enemyOne = pursuer;
                break;
            case 2:
                enemyOne = territorial;
                break;
            case 3:
                enemyOne = sniper;
                break;
            case 4:
                enemyOne = bullrush;
                break;
            case 5:
                enemyOne = spawner;
                break;
        }

        switch ((int)Random.Range(0, 6))
        {
            case 0:
                enemyTwo = wanderer;
                break;
            case 1:
                enemyTwo = pursuer;
                break;
            case 2:
                enemyTwo = territorial;
                break;
            case 3:
                enemyTwo = sniper;
                break;
            case 4:
                enemyTwo = bullrush;
                break;
            case 5:
                enemyTwo = spawner;
                break;
        }

        for(int i = 0; i < primaryEnemyNumber; i++)
        {
            spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
            GameObject e = Instantiate(enemyOne, transform.position, Quaternion.identity);
            e.transform.SetParent(this.transform);
            e.transform.localPosition = spawnPosition;
        }

        for (int i = 0; i < primaryEnemyNumber; i++)
        {
            spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
            GameObject e = Instantiate(enemyTwo, transform.position, Quaternion.identity);
            e.transform.SetParent(this.transform);
            e.transform.localPosition = spawnPosition;
        }
    }
}
