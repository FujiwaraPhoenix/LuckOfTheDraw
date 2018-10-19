using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //Is this a boss?
    public bool isBoss = false;

    //Stuff involving movement, collision, and rigidbody.
    public Rigidbody2D rb;
    public Vector2 inputDir;
    public float mvtSpd;

    //For detection of player
    public float aggroRadius;
    public Vector3 spawnLoc;

    //If the enemy has BullRush AI pattern:
    public bool charging;
    public float stationaryTimer;

    public enum AIType
    {
        Wanderer,
        Pursuer,
        Territorial,
        Sniper,
        Spawner,
        BullRush
    }

    public AIType enemyBehavior;

	// Use this for initialization
	void Start () {
        spawnLoc = new Vector3(transform.position.x, transform.position.y);

    }
	
	// Update is called once per frame
	void Update () {
        runAI(enemyBehavior);
	}


    void runAI(AIType enemyType)
    {
        switch (enemyType)
        {
            case AIType.Wanderer:
                break;
            case AIType.Pursuer:
                playerChase();
                break;
            case AIType.Territorial:
                break;
            case AIType.Sniper:
                break;
            case AIType.Spawner:
                break;
            case AIType.BullRush:
                break;
        }
    }

    //This function returns true if the player is within the detection range and false otherwise.
    bool isPlayerClose(float detectionRadius)
    {
        Vector3 tempVect = new Vector3(Player.pc.transform.position.x - transform.position.x, Player.pc.transform.position.y - transform.position.y);
        float dist = tempVect.magnitude;
        if (dist < detectionRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //This is a function that tells an enemy to chase after a player if they are within a certain distance (aggroRadius).
    void playerChase()
    {
        if (isPlayerClose(aggroRadius))
        {
            Vector3 directionToMove = new Vector3(Player.pc.transform.position.x - transform.position.x,  Player.pc.transform.position.y - transform.position.y);
            directionToMove = directionToMove.normalized;
            rb.velocity = directionToMove * mvtSpd * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void blindRage()
    {

    }
}
