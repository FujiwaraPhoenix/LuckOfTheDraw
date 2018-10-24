using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //Is this a boss?
    public bool isBoss = false;

    //If it is a boss, it needs HP bars. For the sake of simplicity, let's make the bar HP = 50 for now. Also 3 bars total.
    public int hpBarsLeft = 3;
    public int hpReset = 50;

    //General Globals
    public int damage = 5; //How much damage the enemy does per collision
    public int health = 10; //How much damage the enemy takes before dying

    //Stuff involving movement, collision, and rigidbody.
    public Rigidbody2D rb;
    public Vector2 inputDir;
    public float mvtSpd;

    //For detection of player
    public float aggroRadius;
    public Vector3 spawnLoc;

    //If the enemy has BullRush AI pattern:
    public bool dirLocked = false;
    public bool foundPlayer = false;
    public bool charging = false;
    public float stationaryTimer;
    public float chargeTimer;

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
        rb = GetComponent<Rigidbody2D>();
        spawnLoc = new Vector3(transform.position.x, transform.position.y);
        if(isBoss) //Set health depending on enemy type
        {
            health = 50; //Update this once we decide on the actual value
            hpBarsLeft = 3;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        runAI(enemyBehavior);
        if (enemyBehavior != AIType.BullRush && enemyBehavior != AIType.Pursuer && enemyBehavior != AIType.Territorial)
        {
            //Move about normally.
        }
        if (inputDir.magnitude > 1)
        {
            inputDir.Normalize();
        }
        if (enemyBehavior != AIType.Pursuer)
        {
            rb.velocity = inputDir * mvtSpd * Time.deltaTime;
        }
        if (isBoss)
        {
            switch (hpBarsLeft)
            {
                case 1:
                    enemyBehavior = AIType.BullRush;
                    break;
                case 2:
                    enemyBehavior = AIType.Sniper;
                    break;
                case 3:
                    enemyBehavior = AIType.Pursuer;
                    break;
            }
        }
    }


    void runAI(AIType enemyType)
    {
        switch (enemyType)
        {
            case AIType.Wanderer:
                wandererUpdate();
                break;
            case AIType.Pursuer:
                playerChase();
                break;
            case AIType.Territorial:
                break;
            case AIType.Sniper:
                sniperUpdate();
                break;
            case AIType.Spawner:
                spawnerUpdate();
                break;
            case AIType.BullRush:
                blindRage();
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

    //This is a function that tells an enemy to charge in the direction of a player, but not chase them. They simply rush forward until the timer gives, then stop, recalibrate, and rush again.
    void blindRage()
    {
        if (isPlayerClose(aggroRadius))
        {
            foundPlayer = true;
        }
        if (foundPlayer)
        {
            //Locks in the current location of the player...
            if (!dirLocked)
            {
                Vector3 directionToMove = new Vector3(Player.pc.transform.position.x - transform.position.x, Player.pc.transform.position.y - transform.position.y);
                directionToMove = directionToMove.normalized;
                inputDir = directionToMove;
                dirLocked = !dirLocked;
                charging = !charging;
                chargeTimer = 3f;
            }
            //And then goes balls deep after them.
            if (charging && stationaryTimer < 0f)
            {
                if (chargeTimer > 0f)
                {
                    rb.velocity = inputDir * mvtSpd * 2f * Time.deltaTime;
                }
                else
                {
                    stationaryTimer = 3f;
                    charging = !charging;
                }
            }
            //Once they've charged, chill for a sec and find player. Then rush again.
            if (stationaryTimer < 0f && !charging)
            {
                dirLocked = !dirLocked;
            }
            else if (stationaryTimer > 0f)
            {
                inputDir = Vector2.zero;
                rb.velocity = Vector2.zero;
            }
        }
        
        chargeTimer -= Time.deltaTime;
        stationaryTimer -= Time.deltaTime;
    }

    void wandererUpdate() //Put in update for wanderer npcs
    {
        if (wandering) //If wandering, move in the wandering direction
        {
            inputDir = wanderVector;
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
            inputDir = new Vector2(0, 0);
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
        if (isPlayerClose(aggroRadius)) //If the player is in range
        {
            if (shotTimer >= shootCooldown)
            {
                shotTimer = 0;
                ProjectileController p = Instantiate(shot, transform.position + new Vector3(inputDir.x * .1f, inputDir.y * .1f, 0), Quaternion.identity); //Instantiate a bullet
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

    public void isSpawned(Enemy e) //used for spawned enemies
    {
        spawned = true;
        mother = e;
    }

    public void takeDamage(int d) //Method for taking damage, pass the damage dealt as a parameter
    {
        health -= d; //Takes damage
        if(health <= 0 && !isBoss)
        {
            if(spawned) //If it's a spawned enemy, tell the spawner that it's spawned count is one less
            {
                mother.spawnedDied();
            }
            Destroy(this.gameObject); //Destroy itself
        }
        else if (isBoss && health <=0)
        {
            //If it's got more than 3 bars lefts...
            if (hpBarsLeft > 1)
            {
                hpBarsLeft--;
                health = hpReset;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}
