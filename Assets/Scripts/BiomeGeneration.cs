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
    public GameObject rock04;
    public GameObject rock05;
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
    public GameObject beehive;
    public GameObject superRush;
    public int primaryEnemyNumber = 8;
    int primaryEnemyCount = 0;
    public int secondaryEnemyNumber = 5;
    int secondaryEnemyCount = 0;
    GameObject enemyOne;
    GameObject enemyTwo;

    float respawnTimer = 0;
    float respawnCooldown = 60;
    int escalation = 0;

    //these floats will determine how many of each asset will populate the world upon the creation of the individual biome
    public float AmountofTrees;
    public static int asset1Richness;
    float asset1Concentration;
    public float AmountofRocks;
    public static int asset2Richness;
    float asset2Concentration;

    Vector3 spawnPosition;

    bool isDesert = false;
    bool isGrass = false;
    bool isIce = false;

    float biomeNumber;
    GameObject Player;

    // Use this for initialization
    void Start() {
        Player = GameObject.Find("PlayerWithoutCamera");
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
            for (int i = 0; i < AmountofTrees; i++)
            {
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Tree = (GameObject)Instantiate(desertTerrainAsset1, transform.position, Quaternion.identity);
                Tree.transform.SetParent(this.transform);
                Tree.transform.localPosition = spawnPosition;
                Tree.GetComponent<TreeProperties>().FruitGenerator = FruitGen;

            }
            for (int i = 0; i < AmountofRocks; i++)
            {
                rockGenNumber = Random.Range(0, 5);
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                if (rockGenNumber == 0)
                {
                    GameObject Rock = (GameObject)Instantiate(rock01, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 1)
                {
                    GameObject Rock = (GameObject)Instantiate(rock02, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 2)
                {
                    GameObject Rock = (GameObject)Instantiate(rock03, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 3)
                {
                    GameObject Rock = (GameObject)Instantiate(rock04, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 4)
                {
                    GameObject Rock = (GameObject)Instantiate(rock05, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
            }
        }
        if (isGrass)
        {
            for (int i = 0; i < AmountofTrees; i++)
            {
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Tree = (GameObject)Instantiate(grassTerrainAsset1, transform.position, Quaternion.identity);
                Tree.transform.SetParent(this.transform);
                Tree.transform.localPosition = spawnPosition;
                Tree.GetComponent<TreeProperties>().FruitGenerator = FruitGen;

            }
            for (int i = 0; i < AmountofRocks; i++)
            {
                rockGenNumber = Random.Range(0, 5);
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                if (rockGenNumber == 0)
                {
                    GameObject Rock = (GameObject)Instantiate(rock01, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 1)
                {
                    GameObject Rock = (GameObject)Instantiate(rock02, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 2)
                {
                    GameObject Rock = (GameObject)Instantiate(rock03, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 3)
                {
                    GameObject Rock = (GameObject)Instantiate(rock04, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 4)
                {
                    GameObject Rock = (GameObject)Instantiate(rock05, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
            }
        }
        if (isIce)
        {
            for (int i = 0; i < AmountofTrees; i++)
            {
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Tree = (GameObject)Instantiate(iceTerrainAsset1, transform.position, Quaternion.identity);
                Tree.transform.SetParent(this.transform);
                Tree.transform.localPosition = spawnPosition;
                Tree.GetComponent<TreeProperties>().FruitGenerator = FruitGen;

            }
            for (int i = 0; i < AmountofRocks; i++)
            {
                rockGenNumber = Random.Range(0, 5);
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                if (rockGenNumber == 0)
                {
                    GameObject Rock = (GameObject)Instantiate(rock01, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 1)
                {
                    GameObject Rock = (GameObject)Instantiate(rock02, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 2)
                {
                    GameObject Rock = (GameObject)Instantiate(rock03, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 3)
                {
                    GameObject Rock = (GameObject)Instantiate(rock04, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
                if (rockGenNumber == 4)
                {
                    GameObject Rock = (GameObject)Instantiate(rock05, transform.position, Quaternion.identity);
                    Rock.transform.SetParent(this.transform);
                    Rock.transform.localPosition = spawnPosition;
                }
            }
        }
        //Generating enemies
        enemyGenerate();
    }
    // Update is called once per frame
    void Update() {
        if (respawnTimer >= respawnCooldown) //Respawn enemies every minute, and make them stronger for each spawn cycle
        {
            respawnTimer = 0;
            escalation++;
            spawnEnemies();
        }
        else
        {
            respawnTimer += Time.deltaTime;
        }
    }

    void enemyGenerate() //Chooses two enemies to be the enemy types for that biome, and spawns them similarly to the above resources
    {
        GameObject enemyOne = wanderer;
        GameObject enemyTwo = wanderer;

        switch ((int)Random.Range(0, 8))
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
            case 6:
                enemyOne = beehive;
                break;
            case 7:
                enemyOne = superRush;
                break;
        }

        switch ((int)Random.Range(0, 8))
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
            case 6:
                enemyOne = beehive;
                break;
            case 7:
                enemyOne = superRush;
                break;
        }

        for(int i = 0; i < primaryEnemyNumber; i++)
        {
            spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
            GameObject e = Instantiate(enemyOne, transform.position, Quaternion.identity);
            e.transform.SetParent(this.transform);
            e.GetComponent<Enemy>().setHome(this, 1);
            e.transform.localPosition = spawnPosition;
        }

        for (int i = 0; i < primaryEnemyNumber; i++)
        {
            spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
            GameObject e = Instantiate(enemyTwo, transform.position, Quaternion.identity);
            e.transform.SetParent(this.transform);
            e.GetComponent<Enemy>().setHome(this, 2);
            e.transform.localPosition = spawnPosition;
        }
    }

    void spawnEnemies()
    {
        for (int i = primaryEnemyCount; i < primaryEnemyNumber; i++) //Spawn enemies, tell them which biome generator created them, tell them how strong they should be, and increment relevant enemy count
        {
            spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
            GameObject e = Instantiate(enemyOne, transform.position, Quaternion.identity);
            e.transform.SetParent(this.transform);
            e.transform.localPosition = spawnPosition;
            e.GetComponent<Enemy>().setHome(this, 1);
            e.GetComponent<Enemy>().escalate(escalation);
            primaryEnemyCount++;
        }

        for (int i = secondaryEnemyCount; i < primaryEnemyNumber; i++)
        {
            spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
            GameObject e = Instantiate(enemyTwo, transform.position, Quaternion.identity);
            e.transform.SetParent(this.transform);
            e.transform.localPosition = spawnPosition;
            e.GetComponent<Enemy>().setHome(this, 2);
            e.GetComponent<Enemy>().escalate(escalation);
            secondaryEnemyCount++;
        }
    }

    public void enemyDied(int type) //Called by Enemies when they die, decrement the count of spawned enemies
    {
        if(type == 1)
        {
            primaryEnemyCount--;
        }
        else if (type == 2)
        {
            secondaryEnemyCount--;
        }
    }

    /*public void enemyGenerate() //Chooses two enemies to be the enemy types for that biome, and spawns them similarly to the above resources. Obsolete version.
    {
    enemyOne = wanderer;
    enemyTwo = wanderer;
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

    for (int i = primaryEnemyCount; i < primaryEnemyNumber; i++)
    {
        spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
        GameObject e = Instantiate(enemyOne, transform.position, Quaternion.identity);
        e.transform.SetParent(this.transform);
        e.transform.localPosition = spawnPosition;
        e.GetComponent<Enemy>().setHome(this, 1);
        primaryEnemyCount++;
    }

    for (int i = secondaryEnemyCount; i < primaryEnemyNumber; i++)
    {
        spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
        GameObject e = Instantiate(enemyTwo, transform.position, Quaternion.identity);
        e.transform.SetParent(this.transform);
        e.transform.localPosition = spawnPosition;
        e.GetComponent<Enemy>().setHome(this, 2);
        secondaryEnemyCount++;
    }*/
}
