using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyCode : MonoBehaviour {

    Vector2 inputVector;
    Rigidbody2D rb;
    public float speedMult; //Modifies the npc speed

    public int aggroRange = 5; //How close the player has to be for the enemy to chase them
    public int damage = 5; //How much damage the enemy does per collision

    //Wander Globals
    bool wandering = false; //Whether or not the NPC is wandering around
    float wanderTimer = 0; //Timer for wandering purposes
    public float wanderTimerMax = 4; //Maximum wandering time
    public float wanderTimerMin = 0.5f; //Minimum wandering time
    public float wanderCooldownMax = 5; //Maximum time waiting between wandering
    public float wanderCooldownMin = 1; //Minimum time waiting between wandering
    float wanderCooldown = 5; //How long this period of waiting should last
    float wanderTime; //How long this period of wandering should last
    Vector2 wanderVector; //The direction the NPC wanders in

    //Sniper Globals
    public float shootCooldown = 2; //How long it waits before shooting
    float shotTimer = 0; //Timer for shooting
    public ProjectileController shot; //The prefab for the projectile

    //Spawner Globals
    public float spawnCooldown = 1;
    float spawnTimer = 0;
    public int spawnMax = 5;
    int spawnedEnemies = 0;

    //Spawned Globals
    bool spawned = false;
    Enemy mother;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void wandererUpdate() //Put in update for wanderer npcs
    {
        if (wandering) //If wandering, move in the wandering direction
        {
            inputVector = wanderVector;
            wanderTimer += Time.deltaTime;
            if (wanderTimer >= wanderTime) //If the timer runs out, set to stay still for a random amount of time
            {
                wanderTimer = 0;
                wanderVector = new Vector2(0, 0);
                wandering = false;
                wanderCooldown = Random.Range(wanderCooldownMin, wanderCooldownMax);
            }
        }
        else //Stay still for a while

        {
            inputVector = new Vector2(0, 0);
            wanderTimer += Time.deltaTime;
            if (wanderTimer >= wanderCooldown) //If the timer runs out, set a random wander direction and how long it should wander that way
            {
                wanderTimer = 0;
                wanderVector = Random.insideUnitCircle;
                wandering = true;
                wanderTime = Random.Range(wanderTimerMin, wanderTimerMax);
            }
        }
    }

    void sniperUpdate() //Put in update for sniper npcs
    {
        if (Vector3.Distance(Player.pc.transform.position, transform.position) < aggroRange) //If the player is in range
        {
            if (shotTimer >= shootCooldown)
            {
                shotTimer = 0;
                ProjectileController p = Instantiate(shot, transform.position + new Vector3(inputVector.x * .1f, inputVector.y * .1f, 0), Quaternion.identity); //Instantiate a bullet
                p.target(Player.pc.transform.position, damage); //Tell the bullet where to go
            }
            else
            {
                shotTimer += Time.deltaTime;
            }
        }
    }

    void spawnerUpdate() //Put in update for spawner npcs
    {
        if (spawnedEnemies < spawnMax && spawnTimer >= spawnCooldown)
        {
            spawnTimer = 0;
            //Enemy e = Instantiate an enemy
            //e.isSpawned(this.Enemy);

        }
        else if (spawnedEnemies < spawnMax)
        {
            spawnTimer += Time.deltaTime;
        }
    }

    public void spawnedDied() //Used for spawners
    {
        spawnedEnemies--;
    }

    void spawnedCode() //Add right before a spawned enemy destroys itself when dying
    {
        //mother.spawnedDied(); //Tell what spawned it to decrement spawnedEnemies (Commented out to avoid a compiler error, should be fine when pasted in)
    }

    public void isSpawned(Enemy e) //used for spawned enemies
    {
        spawned = true;
        mother = e;
    }

    private void FixedUpdate() //For movement purposes
    {
        if (inputVector.magnitude > 1)
        {
            inputVector.Normalize();
        }
        rb.velocity = inputVector * speedMult * Time.deltaTime;
    }
}
