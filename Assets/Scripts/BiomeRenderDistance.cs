using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeRenderDistance : MonoBehaviour {
    public GameObject player;
    public GameObject InnerBiome1;
    public GameObject InnerBiome2;
    public GameObject InnerBiome3;
    public GameObject InnerBiome4;
    public GameObject InnerBiome5;
    public GameObject InnerBiome6;
    public GameObject OuterBiome1;
    public GameObject OuterBiome2;
    public GameObject OuterBiome3;
    public GameObject OuterBiome4;
    public GameObject OuterBiome5;
    public GameObject OuterBiome6;
    public GameObject OuterBiome7;
    public GameObject OuterBiome8;
    public GameObject OuterBiome9;
    public GameObject OuterBiome10;
    public GameObject OuterBiome11;
    public GameObject OuterBiome12;

    float renderDistance = 25f;

    GameObject[] lostFruit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector2.Distance(player.transform.position, InnerBiome1.transform.position));
		if(Vector2.Distance(player.transform.position, InnerBiome1.transform.position) > renderDistance)
        {
            InnerBiome1.gameObject.SetActive(false);
        }
        else
        {
            InnerBiome1.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome2.transform.position) > renderDistance)
        {
            InnerBiome2.gameObject.SetActive(false);
        }
        else
        {
            InnerBiome2.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome3.transform.position) > renderDistance)
        {
            InnerBiome3.gameObject.SetActive(false);
        }
        else
        {
            InnerBiome3.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome4.transform.position) > renderDistance)
        {
            InnerBiome4.gameObject.SetActive(false);
        }
        else
        {
            InnerBiome4.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome5.transform.position) > renderDistance)
        {
            InnerBiome5.gameObject.SetActive(false);
        }
        else
        {
            InnerBiome5.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome6.transform.position) > renderDistance)
        {
            InnerBiome6.gameObject.SetActive(false);
        }
        else
        {
            InnerBiome6.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome1.transform.position) > renderDistance)
        {
            OuterBiome1.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome1.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome2.transform.position) > renderDistance)
        {
            OuterBiome2.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome2.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome3.transform.position) > renderDistance)
        {
            OuterBiome3.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome3.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome4.transform.position) > renderDistance)
        {
            OuterBiome4.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome4.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome5.transform.position) > renderDistance)
        {
            OuterBiome5.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome5.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome6.transform.position) > renderDistance)
        {
            OuterBiome6.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome6.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome7.transform.position) > renderDistance)
        {
            OuterBiome7.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome7.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome8.transform.position) > renderDistance)
        {
            OuterBiome8.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome8.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome9.transform.position) > renderDistance)
        {
            OuterBiome9.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome9.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome10.transform.position) > renderDistance)
        {
            OuterBiome10.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome10.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome11.transform.position) > renderDistance)
        {
            OuterBiome11.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome11.gameObject.SetActive(true);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome12.transform.position) > renderDistance)
        {
            OuterBiome12.gameObject.SetActive(false);
        }
        else
        {
            OuterBiome12.gameObject.SetActive(true);
        }

        GameObject lostFruit1 = GameObject.Find("FruitPreFab1(Clone)");
        GameObject lostFruit2 = GameObject.Find("FruitPreFab2(Clone)");
        GameObject lostFruit3 = GameObject.Find("FruitPreFab3(Clone)");
        Destroy(lostFruit1);
        Destroy(lostFruit2);
        Destroy(lostFruit3);


    }
}
