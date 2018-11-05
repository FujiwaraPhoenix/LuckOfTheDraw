using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour { //Enemies must have the enemy tag and layer, and have a deactivated sprite parented to them for effect icon display

    //Is this a boss?
    public bool isBoss = false;

    //If it is a boss, it needs HP bars. For the sake of simplicity, let's make the bar HP = 50 for now. Also 3 bars total.
    public int hpBarsLeft = 3;
    public int hpReset = 50;

    //General Globals
    public int damage = 5; //How much damage the enemy does per collision
    public int health = 10; //How much damage the enemy takes before dying
    public BiomeGeneration homeBiome; //Used for generation and respawning purposes
    int generationType;

    //Spriting Globals
    SpriteRenderer sr;

    //Stuff involving movement, collision, and rigidbody.
    public Rigidbody2D rb;
    public Vector2 inputDir;
    public float mvtSpd;

    //For detection of player
    public float aggroRadius;
    public Vector3 spawnLoc;
    public float territoryRadius = 5f;

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
    public float spawnCooldown = 3;
    float spawnTimer = 0;
    public int spawnMax = 3;
    int spawnedEnemies = 0;
    public GameObject enemyToSpawn;

    //Spawned Globals
    bool spawned = false;
    Enemy mother;

    //Possible status effects.
    public int currentStatus = 0;
    public float tickrate = 2f;
    public float tickTimer = 0f;
    public int ticksRemaining;

    //Feedback Globals
    //float flash = 1;
    float maxHealth;
    public GameObject effectIcon;
    public SpriteRenderer effectSprites;
    public Sprite[] effectList = new Sprite[2];

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
        sr = GetComponent<SpriteRenderer>();
        spawnLoc = new Vector3(transform.position.x, transform.position.y);
        if(isBoss) //Set health depending on enemy type
        {
            //health = 50; //Update this once we decide on the actual value
            hpBarsLeft = 3;
        }
        maxHealth = health;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Flashes red when damage is taken
        sr.color = new Color(1, (health/maxHealth), (health/maxHealth));
        /*if(flash < 1)
        {
            flash += 0.2f;
        }*/

        
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
                    Debug.Log("Phase 2");
                    enemyBehavior = AIType.Sniper;
                    break;
                case 3:
                    enemyBehavior = AIType.Pursuer;
                    break;
            }
        }

        runAI(enemyBehavior);

        if (currentStatus != 0)
        {
            if (ticksRemaining > 0)
            {
                switch (currentStatus)
                {
                    case 1:
                        if (tickTimer <= 0)
                        {
                            takeDamage(1);
                            ticksRemaining--;
                            tickTimer = tickrate;
                        }
                        break;
                    case 5:
                        if (tickTimer > 0)
                        {
                            //This one ticks once, so...
                            rb.velocity *= .5f;
                        }
                        else
                        {
                            ticksRemaining--;
                            tickTimer = tickrate;
                        }
                        break;
                }
            }
            else
            {
                effectIcon.SetActive(false);
            }
            tickTimer -= Time.deltaTime;
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
                territorialAnger();
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
                    rb.velocity = inputDir * mvtSpd * Time.deltaTime;
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
            GameObject spawned = Instantiate(enemyToSpawn, new Vector3(transform.position.x + .5f, transform.position.y + .5f, transform.position.z), Quaternion.identity);
            spawned.GetComponent<Enemy>().isSpawned(this);
            spawnedEnemies++;

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
        //flash = 0;
        if(health <= 0 && !isBoss)
        {
            if(spawned) //If it's a spawned enemy, tell the spawner that it's spawned count is one less
            {
                mother.spawnedDied();
            }
            Debug.Log("DIE.");
            if (!spawned)
            {
                homeBiome.enemyDied(generationType); //Tell the biome generator that it can spawn another enemy next respawn cycle
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
                Controller.Instance.bossBeaten = true;
                Destroy(this.gameObject);
            }
        }
    }

    public void setEffect(int type) //Sets a status effect
    {
        currentStatus = type; //1 is poison, 5 is slow
        if(currentStatus == 1)
        {
            effectIcon.SetActive(true);
            effectSprites.sprite = effectList[0];
            tickrate = 1f;
            ticksRemaining = 10;
        }
        else if (currentStatus == 5)
        {
            effectIcon.SetActive(true);
            effectSprites.sprite = effectList[1];
            tickrate = 5f;
            ticksRemaining = 2;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit Something");
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit a player");
            Player p = collision.gameObject.GetComponent<Player>();
            p.getHit(damage);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) //Since triggers can only collide on the non-trigger script, this is needed for piercing bullets to work
    {
        if (collision.GetComponent<PlayerBullet>() != null)
        {
            PlayerBullet pb = collision.GetComponent<PlayerBullet>();
            takeDamage(pb.damage);
        }
    }

    /*public void territorialAnger()
    {
        float distance = Vector3.Distance (transform.position, spawnLoc);
        if (isPlayerClose(aggroRadius) && (distance < territoryRadius))
        {
            Vector3 directionToMove = new Vector3(Player.pc.transform.position.x - transform.position.x, Player.pc.transform.position.y - transform.position.y);
            directionToMove = directionToMove.normalized;
            rb.velocity = directionToMove * mvtSpd * Time.deltaTime;
        }
        else if (!isPlayerClose(aggroRadius))
        {
            Vector3 directionToMove = new Vector3(spawnLoc.x - transform.position.x, spawnLoc.y - transform.position.y);
            directionToMove = directionToMove.normalized;
            rb.velocity = directionToMove * mvtSpd * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }*/
    public void territorialAnger()
    {
        float distance = Vector3.Distance(transform.position, spawnLoc);
        if (isPlayerClose(aggroRadius))
        {
            //Debug.Log("Chasing");
            Vector3 directionToMove = new Vector3(Player.pc.transform.position.x - transform.position.x, Player.pc.transform.position.y - transform.position.y);
            directionToMove = directionToMove.normalized;
            inputDir = directionToMove;
            //rb.velocity = directionToMove * mvtSpd * Time.deltaTime;
        }
        else if (!isPlayerClose(aggroRadius))
        {
            //Debug.Log("Not Chasing");
            Vector3 directionToMove = new Vector3(spawnLoc.x - transform.position.x, spawnLoc.y - transform.position.y);
            directionToMove = directionToMove.normalized;
            inputDir = directionToMove;
            //rb.velocity = directionToMove * mvtSpd * Time.deltaTime;
        }
        //else
        //{
          //  rb.velocity = Vector2.zero;
        //}
    }

    public void setHome(BiomeGeneration h, int t)
    {
        homeBiome = h;
        generationType = t;
    }

    public void escalate(int cycle)
    {
        health += 2 * cycle;
        damage += 2 * cycle;
    }
}
