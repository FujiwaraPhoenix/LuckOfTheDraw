using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float sdTimer, checkForObj, dist, checksLeft, checkRate;

    public int dmg;

    // Use this for initialization
    void Start () {
        //dist = GetComponent<CircleCollider2D>().radius;
	}
	
	// Update is called once per frame
	void Update () {
        if (checkForObj < 0)
        {
            Collider2D[] check = Physics2D.OverlapCircleAll(transform.position, dist);
            for (int i = 0; i < check.Length; i++)
            {
                Collider2D currentGO = check[i];
                if (currentGO.GetComponent<Enemy>() != null)
                {
                    currentGO.GetComponent<Enemy>().takeDamage(dmg);
                }
                else if (currentGO.GetComponent<Player>() != null)
                {
                    currentGO.GetComponent<Player>().getHit(dmg);
                }
            }
            checkForObj = checkRate;
        }
        if (sdTimer < 0)
        {
            Destroy(gameObject);
        }
        sdTimer -= Time.deltaTime;
        checkForObj -= Time.deltaTime;
    }
}
