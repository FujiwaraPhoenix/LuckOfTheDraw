using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGenerator : MonoBehaviour {
    public Sprite leaves01;
    public Sprite leaves02;
    public Sprite leaves03;
    float leavesNumber;

    // Use this for initialization
    void Start () {
        leavesNumber = Random.Range(0f, 3f);
        if (leavesNumber >= 0f && leavesNumber < 1f)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = leaves01;
        }
        if (leavesNumber >= 1f && leavesNumber < 2f)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = leaves02;
        }
        if (leavesNumber >= 2f && leavesNumber < 3f)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = leaves03;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
