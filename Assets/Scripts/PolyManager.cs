using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyManager : MonoBehaviour {

    //public string BiomeType -- for later
    public int number;
    public int size;
   // public int proximity; -- for later
   // public int cluster; -- for later
    public int colorfluctuation;
    private Color TheColor;
    public Vector3 LargeRock;
    public Vector3 SmallRock;
    public string stretch;
    private float LargeRockRandomSize;
    private float SmallRockRandomSize;

    private GameObject[] Hexs = new GameObject[20];
    private GameObject[] clusterHexs = new GameObject[60];
    private int listCount = 0;
    public GameObject Hex;
    public GameObject Rock_Impassable_1;
    public GameObject Rock_Impassable_2;
    public GameObject Rock_Impassable_3;
    public GameObject Tree_Impassable;
    public GameObject Pillar_Impassable_1;
    public GameObject Pillar_Impassable_2;
    public GameObject Pillar_Impassable_3;
    public GameObject ShortPillar_Impassable_1;
    public GameObject ShortPillar_Impassable_2;
    public GameObject ShortPillar_Impassable_3;
    public GameObject SkullPillar_Impassable;
    public GameObject Carcass_Impassable_1;
    public GameObject Carcass_Impassable_2;

    public GameObject terrain;
    Vector3 spawnPosition;
    Vector3 clusterspawnPosition;

    // Use this for initialization
    void Start () {
        Generate();
		
	}
	
	// Update is called once per frame
	void Update () {
        //this can be replaced with at the start of the scene, do this for each biome
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Generate();
        //}
		
	}

    //this function makes the hexs
    void Generate() {
        //destroy current hexs in the scene
        //GameObject[] destroys = GameObject.FindGameObjectsWithTag("Hexs");
        //foreach(GameObject destroy in destroys)
        //{
        //    GameObject.Destroy(destroy);
        //}

        //pick a number of hexs to make

        //make them
        number = Random.Range(1, 20);

        for (int i = 0; i < number; i++)
        {
            spawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-8f, 8f), -1f);
            float clusterNumber = Random.Range(0f, 3f);
            int terrainNumber = Random.Range(0, 13);
            if(terrainNumber == 0)
            {
                terrain = (GameObject)Instantiate(Rock_Impassable_1, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 1)
            {
                terrain = (GameObject)Instantiate(Rock_Impassable_2, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 2)
            {
                terrain = (GameObject)Instantiate(Rock_Impassable_3, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 3)
            {
                terrain = (GameObject)Instantiate(Tree_Impassable, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 4)
            {
                terrain = (GameObject)Instantiate(Pillar_Impassable_1, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 5)
            {
                terrain = (GameObject)Instantiate(Pillar_Impassable_2, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 6)
            {
                terrain = (GameObject)Instantiate(Pillar_Impassable_3, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 7)
            {
                terrain = (GameObject)Instantiate(ShortPillar_Impassable_1, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 8)
            {
                terrain = (GameObject)Instantiate(ShortPillar_Impassable_2, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 9)
            {
                terrain = (GameObject)Instantiate(ShortPillar_Impassable_3, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 10)
            {
                terrain = (GameObject)Instantiate(SkullPillar_Impassable, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 11)
            {
                terrain = (GameObject)Instantiate(Carcass_Impassable_1, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            if (terrainNumber == 12)
            {
                terrain = (GameObject)Instantiate(Carcass_Impassable_2, transform.position, Quaternion.identity);
                terrain.transform.SetParent(this.transform);
                terrain.transform.localPosition = spawnPosition;
                Hexs[i] = terrain;
            }
            //GameObject terrain = (GameObject)Instantiate(Hex, transform.position, Quaternion.identity);
            //terrain.transform.SetParent(this.transform);
            //terrain.transform.localPosition = spawnPosition;
            //Hexs[i] = terrain;

            if (terrainNumber == 0 || terrainNumber == 1 || terrainNumber == 2)
            {
                for (int a = 0; a < clusterNumber; a++)
                {
                    clusterspawnPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -1f);
                    if (terrainNumber == 0)
                    {
                        GameObject clusterHex = (GameObject)Instantiate(Rock_Impassable_1, terrain.transform.position, Quaternion.identity);
                        clusterHex.transform.SetParent(terrain.transform);
                        clusterHex.transform.localPosition = clusterspawnPosition;
                        clusterHex.transform.localScale = new Vector3(LargeRockRandomSize, LargeRockRandomSize, LargeRockRandomSize);
                        clusterHexs[listCount] = clusterHex;
                        listCount += 1;
                    }
                    if (terrainNumber == 1)
                    {
                        GameObject clusterHex = (GameObject)Instantiate(Rock_Impassable_2, terrain.transform.position, Quaternion.identity);
                        clusterHex.transform.SetParent(terrain.transform);
                        clusterHex.transform.localPosition = clusterspawnPosition;
                        clusterHex.transform.localScale = new Vector3(LargeRockRandomSize, LargeRockRandomSize, LargeRockRandomSize);
                        clusterHexs[listCount] = clusterHex;
                        listCount += 1;
                    }
                    if (terrainNumber == 2)
                    {
                        GameObject clusterHex = (GameObject)Instantiate(Rock_Impassable_3, terrain.transform.position, Quaternion.identity);
                        clusterHex.transform.SetParent(terrain.transform);
                        clusterHex.transform.localPosition = clusterspawnPosition;
                        clusterHex.transform.localScale = new Vector3(LargeRockRandomSize, LargeRockRandomSize, LargeRockRandomSize);
                        clusterHexs[listCount] = clusterHex;
                        listCount += 1;
                    }
                    //GameObject clusterHex = (GameObject)Instantiate(Hex, terrain.transform.position, Quaternion.identity);
                    //clusterHex.transform.SetParent(terrain.transform);
                    //clusterHex.transform.localPosition = clusterspawnPosition;
                    //clusterHex.transform.localScale = new Vector3(RandomSize, RandomSize, RandomSize);
                    //clusterHexs[listCount] = clusterHex;
                    //listCount += 1;
                    //terrain = null;
                }
            }
            terrain = null;
        }

        //pick a random size and color
        LargeRockRandomSize = Random.Range(0.2f, 0.4f);
        SmallRockRandomSize = Random.Range(0.5f, 1f);
        TheColor = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 1f);
        LargeRock = new Vector3(LargeRockRandomSize, LargeRockRandomSize, LargeRockRandomSize);
        SmallRock = new Vector3(SmallRockRandomSize, SmallRockRandomSize, SmallRockRandomSize);

        //Hexs = GameObject.FindGameObjectsWithTag("Hexs");
        Debug.Log(Hexs.Length);
        Debug.Log(clusterHexs.Length);

        foreach(GameObject hex in Hexs)
        {
            if (hex != null)
            {
                hex.GetComponent<SpriteRenderer>().color = TheColor;
                hex.GetComponent<Transform>().localScale = LargeRock;
            }
        }
        
        foreach (GameObject clusterhex in clusterHexs)
        {
            if (clusterhex != null)
            {
                clusterhex.GetComponent<SpriteRenderer>().color = TheColor;
                clusterhex.GetComponent<Transform>().localScale = SmallRock;
            }
        }



    }
}
