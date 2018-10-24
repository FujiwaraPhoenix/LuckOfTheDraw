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
    public Vector3 TheScale;
    public string stretch;
    private float RandomSize;

    private GameObject[] Hexs = new GameObject[20];
    private GameObject[] clusterHexs = new GameObject[60];
    private int listCount = 0;
    public GameObject Hex;

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
            GameObject terrain = (GameObject)Instantiate(Hex, transform.position, Quaternion.identity);
            terrain.transform.SetParent(this.transform);
            terrain.transform.localPosition = spawnPosition;
            Hexs[i] = terrain;
            for (int a = 0; a < clusterNumber; a++)
            {
                clusterspawnPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -1f);
                GameObject clusterHex = (GameObject)Instantiate(Hex, terrain.transform.position, Quaternion.identity);
                clusterHex.transform.SetParent(terrain.transform);
                clusterHex.transform.localPosition = clusterspawnPosition;
                clusterHex.transform.localScale = new Vector3(RandomSize, RandomSize, RandomSize);
                clusterHexs[listCount] = clusterHex;
                listCount += 1;
            }
        }

        //pick a random size and color
        RandomSize = Random.Range(0.5f, 1f);
        TheColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        TheScale = new Vector3(RandomSize, RandomSize, RandomSize);
        //Hexs = GameObject.FindGameObjectsWithTag("Hexs");
        

        foreach(GameObject hex in Hexs)
        {
            if (hex != null)
            {
                hex.GetComponent<SpriteRenderer>().color = TheColor;
                hex.GetComponent<Transform>().localScale = TheScale;
            }
        }
        
        foreach (GameObject clusterhex in clusterHexs)
        {
            if (clusterhex != null)
            {
                clusterhex.GetComponent<SpriteRenderer>().color = TheColor;
                clusterhex.GetComponent<Transform>().localScale = TheScale;
            }
        }



    }
}
