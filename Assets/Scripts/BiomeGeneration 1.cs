using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGeneration : MonoBehaviour {
    //these gameobjects will be the specific prefabs for the objects that will exist within the world(e.g trees, boulders, ponds, etc.)
    public GameObject desertTerrainAsset1;
    public GameObject desertTerrainAsset2;
    public GameObject desertTerrainAsset3;

    public GameObject grassTerrainAsset1;
    public GameObject grassTerrainAsset2;
    public GameObject grassTerrainAsset3;

    public GameObject iceTerrainAsset1;
    public GameObject iceTerrainAsset2;
    public GameObject iceTerrainAsset3;

    //these floats will determine how many of each asset will populate the world upon the creation of the individual biome
    public float amountOfAsset1;
    public float amountOfAsset2;
    public float amountOfAsset3;
    float amountOfPlants = 10f;

    Vector3 spawnPosition;

    bool isDesert = false;
    bool isGrass = false;
    bool isIce = false;

    // Use this for initialization
    void Start () {
        //this will ensure that the biome has a randomly picked color upon activation
        if (this.gameObject.tag == "DesertTile")
        {
            isDesert = true;
        }
        if (this.gameObject.tag == "GrassTile")
        {
            isGrass = true;
        }
        if (this.gameObject.tag == "IceTile")
        {
            isIce = true;
        }
        this.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
        float textureNumber = Random.Range(0, 3);

        //these for statements will populate the world accordingly with how mnay of a specific asset you want at randomized locations with 
        //randomized size as well.
        if (isDesert)
        {
            for (int i = 0; i < amountOfAsset1; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(desertTerrainAsset1, transform.position, Quaternion.identity);
               // biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;

            }
            for (int i = 0; i < amountOfAsset2; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(desertTerrainAsset2, transform.position, Quaternion.identity);
              //  biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;

            }
            for (int i = 0; i < amountOfAsset3; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(desertTerrainAsset3, transform.position, Quaternion.identity);
               // biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;
            }
            for(int i = 0; i < amountOfPlants; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                EdiblePlant plant = Controller.Instance.speciesList[0];
                EdiblePlant terrainPlant = (EdiblePlant)Instantiate(plant, transform.position, Quaternion.identity);
                terrainPlant.transform.SetParent(this.transform);
                terrainPlant.transform.localPosition = spawnPosition;
            }
        }
        if (isGrass)
        {
            for (int i = 0; i < amountOfAsset1; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(grassTerrainAsset1, transform.position, Quaternion.identity);
              //  biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;

            }
            for (int i = 0; i < amountOfAsset2; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(grassTerrainAsset2, transform.position, Quaternion.identity);
             //   biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;

            }
            for (int i = 0; i < amountOfAsset3; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(grassTerrainAsset3, transform.position, Quaternion.identity);
             //   biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;
            }
            for (int i = 0; i < amountOfPlants; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                EdiblePlant plant = Controller.Instance.speciesList[1];
                EdiblePlant terrainPlant = (EdiblePlant)Instantiate(plant, transform.position, Quaternion.identity);
                terrainPlant.transform.SetParent(this.transform);
                terrainPlant.transform.localPosition = spawnPosition;
            }
        }
        if (isIce)
        {
            for (int i = 0; i < amountOfAsset1; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(iceTerrainAsset1, transform.position, Quaternion.identity);
             //   biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;

            }
            for (int i = 0; i < amountOfAsset2; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(iceTerrainAsset2, transform.position, Quaternion.identity);
              //  biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;

            }
            for (int i = 0; i < amountOfAsset3; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                GameObject biome = (GameObject)Instantiate(iceTerrainAsset3, transform.position, Quaternion.identity);
              //  biome.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 1);
                biome.transform.SetParent(this.transform);
                biome.transform.localPosition = spawnPosition;
            }
            for (int i = 0; i < amountOfPlants; i++)
            {
                spawnPosition = new Vector3(Random.Range(-0.65f, 0.65f), -1f, Random.Range(-0.65f, 0.65f));
                EdiblePlant plant = Controller.Instance.speciesList[2];
                EdiblePlant terrainPlant = (EdiblePlant)Instantiate(plant, transform.position, Quaternion.identity);
                terrainPlant.transform.SetParent(this.transform);
                terrainPlant.transform.localPosition = spawnPosition;
            }
        }
    }

    // Update is called once per frame
    void Update() { 
    }
}
