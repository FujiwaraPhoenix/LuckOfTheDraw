using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public Vector3 travelDir;
    public bool isSine = false;
    public int aftereffect = 0;
    public float mvtSpd = 10;
    public int damage = 1;
    public float lifetime = 3;
    public bool isTracking = false;
    public Enemy trackingTarget;
    public Explosion e;
    public GameObject explosionPreFab;

    int gunIndex;
    int shotIndex;
    int effectIndex;

    float timer = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isTracking)
        {
            transform.position += travelDir * mvtSpd * Time.deltaTime;
        }
        //Debug.Log(Mathf.Cos(timer) + " " + Mathf.Sin(timer));

        if (shotIndex == 2) //If the bullet has acceleration
        {
            mvtSpd += 15 * Time.deltaTime;
        }
        if (isTracking)
        {
            tracking();
        }
        if(timer >= lifetime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
	}

    public void setIndices(int g, int s, int e) //Sets the modifiers for the shot when it is shot
    {
        gunIndex = g;
        shotIndex = s;
        effectIndex = e;

        switch (gunIndex)
        {
            case 3:
                //Hard coding rn for the sake of testing.
                damage = 3;
                break;
        }

        switch(shotIndex)
        {
            case 3:
                mvtSpd = 20;
                break;
            case 2: //Temporary; sine wave otherwise. Currently acceleration.
                mvtSpd = 5;
                break;
            case 1:
                lifetime = 7.5f;
                break;
            case 6:
                //Set tracking true.
                isTracking = true;
                break;
            case 4:
                transform.localScale *= 1.5f;
                break;
        }

        switch(effectIndex)
        {
            case 4:
                BoxCollider2D boxCol = GetComponent<BoxCollider2D>();
                boxCol.isTrigger = true;
                break;
        }
    }

    public void tracking()
    {
        //First, we find the nearest enemy.
        //If we don't have one yet, this'll find one for us.
        if (trackingTarget == null)
        {
            transform.position += travelDir * mvtSpd * Time.deltaTime;
            Collider2D[] foundTargets = Physics2D.OverlapCircleAll(transform.position, 3f);
            bool foundTarget = false;
            for (int i = 0; i < foundTargets.Length; i++)
            {
                if (!foundTarget)
                {
                    if (foundTargets[i].GetComponent<Enemy>() != null)
                    {
                        foundTarget = true;
                        trackingTarget = foundTargets[i].GetComponent<Enemy>();
                    }
                }
            }
        }
        //Now if we have one...
        else
        {
            Vector3 directionToMove = new Vector3(trackingTarget.transform.position.x - transform.position.x, trackingTarget.transform.position.y - transform.position.y);
            directionToMove = directionToMove.normalized;
            transform.position += directionToMove.normalized * mvtSpd * Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy tempEnemy = collision.gameObject.GetComponent<Enemy>();
            tempEnemy.takeDamage(damage);
            switch (effectIndex)
            {
                //Take 1dmg/tick.
                case 3:
                    //tempEnemy.currentStatus = 1;
                    //tempEnemy.ticksRemaining = 10;
                    //tempEnemy.tickrate = 1f;
                    tempEnemy.setEffect(1);
                    break;
                //Drop an AoE.
                case 5:
                    Explosion newExp = Instantiate(e, transform.position, Quaternion.identity);
                    //GameObject newExp = (GameObject)Instantiate(explosionPreFab, transform.position, Quaternion.identity);
                    newExp.dmg = damage;
                    break;
                //Bounce
                case 1:
                    Vector3 newDirection = (Vector3.Reflect(travelDir, collision.contacts[0].normal));
                    travelDir = (Vector2)newDirection;
                    break;
                //Slow the enemy.
                case 2:
                    //tempEnemy.currentStatus = 5;
                    //tempEnemy.ticksRemaining = 1;
                    //tempEnemy.tickrate = 5f;
                    tempEnemy.setEffect(5);
                    break;
            }
            if (effectIndex != 1 && effectIndex != 4)
            {
                Debug.Log("Destroying bullet");
                Destroy(this.gameObject);
            }
            else
            {
                //Debug.Log("Shouldn't be destroyed");
            }
            if(gunIndex == 6 && Player.pc.health < 30) //Lifesteal, EDIT THE IF STATEMENT IF THE PLAYER GETS A MAX HEALTH VARIABLE
            {
                Player.pc.health++;
                //Potentially edit if we have a method for healing instead of manually changing the value
            }
        }
        else if (collision.gameObject.tag.Equals("Hexs")) //Bounce
        {
            if (effectIndex == 1)
            {
                Vector3 newDirection = (Vector3.Reflect(travelDir, collision.contacts[0].normal));
                travelDir = (Vector2)newDirection;
            }
        }
        else if (collision.gameObject.tag.Equals("BorderWall") || (collision.gameObject.tag.Equals("Tree") && effectIndex != 1))
        {
            Destroy(this.gameObject);
        }
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (effectIndex == 4)
        {
            Enemy tempEnemy = collision.gameObject.GetComponent<Enemy>();
            tempEnemy.health -= damage;
            Debug.Log("Damaging");
        }
    }*/
}
