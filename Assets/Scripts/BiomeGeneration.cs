using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGeneration : MonoBehaviour {
    //these gameobjects will be the specific prefabs for the objects that will exist within the world(e.g trees, boulders, ponds, etc.)
    public Sprite desert;
    public Sprite grassland;
    public Sprite iceTundra;

    public GameObject desertTerrainAsset1;
    public GameObject desertTerrainAsset2;
    public GameObject desertTerrainAsset3;

    public GameObject grassTerrainAsset1;
    public GameObject grassTerrainAsset2;
    public GameObject grassTerrainAsset3;

    public GameObject iceTerrainAsset1;
    public GameObject iceTerrainAsset2;
    public GameObject iceTerrainAsset3;

    public GameObject FruitGen;

    //these floats will determine how many of each asset will populate the world upon the creation of the individual biome
    public float amountOfAsset1;
    public static int asset1Richness;
    float asset1Concentration;
    public float amountOfAsset2;
    public static int asset2Richness;
    float asset2Concentration;
    public float amountOfAsset3;
    public static int asset3Richness;
    float asset3Concentration;

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
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Rock = (GameObject)Instantiate(desertTerrainAsset2, transform.position, Quaternion.identity);
                Rock.transform.SetParent(this.transform);
                Rock.transform.localPosition = spawnPosition;

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
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Rock = (GameObject)Instantiate(grassTerrainAsset2, transform.position, Quaternion.identity);
                Rock.transform.SetParent(this.transform);
                Rock.transform.localPosition = spawnPosition;

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
                spawnPosition = new Vector3(Random.Range(-4f, 2f), Random.Range(-3f, 3f), -1f);
                GameObject Rock = (GameObject)Instantiate(iceTerrainAsset2, transform.position, Quaternion.identity);
                Rock.transform.SetParent(this.transform);
                Rock.transform.localPosition = spawnPosition;

            }
        }
    }

    // Update is called once per frame
    void Update() { 
    }
}
