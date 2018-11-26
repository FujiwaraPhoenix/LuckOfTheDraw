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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(player.transform.position, InnerBiome1.transform.position) > 200f)
        {
            InnerBiome1.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome2.transform.position) > 200f)
        {
            InnerBiome2.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome3.transform.position) > 200f)
        {
            InnerBiome3.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome4.transform.position) > 200f)
        {
            InnerBiome4.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome5.transform.position) > 200f)
        {
            InnerBiome5.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, InnerBiome6.transform.position) > 200f)
        {
            InnerBiome6.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome1.transform.position) > 200f)
        {
            OuterBiome1.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome2.transform.position) > 200f)
        {
            OuterBiome2.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome3.transform.position) > 200f)
        {
            OuterBiome3.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome4.transform.position) > 200f)
        {
            OuterBiome4.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome5.transform.position) > 200f)
        {
            OuterBiome5.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome6.transform.position) > 200f)
        {
            OuterBiome6.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome7.transform.position) > 200f)
        {
            OuterBiome7.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome8.transform.position) > 200f)
        {
            OuterBiome8.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome9.transform.position) > 200f)
        {
            OuterBiome9.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome10.transform.position) > 200f)
        {
            OuterBiome10.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome11.transform.position) > 200f)
        {
            OuterBiome11.gameObject.SetActive(false);
        }
        if (Vector2.Distance(player.transform.position, OuterBiome12.transform.position) > 200f)
        {
            OuterBiome12.gameObject.SetActive(false);
        }

    }
}
