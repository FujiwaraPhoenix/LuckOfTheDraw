using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrow : MonoBehaviour
{

    float colorFlash = 1;
    public GameObject bosspos;
    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Boss_pos = bosspos.transform.position;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        Boss_pos.x = Boss_pos.x - player_pos.x;
        Boss_pos.y = Boss_pos.y - player_pos.y;

        float angle = Mathf.Atan2(Boss_pos.y, Boss_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        


    }


}


