using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour {

    public  int speed;
    public static int regen;
    public int health;
    public static float hunger;
    public GameObject fruit;
    public Transform player;
    float fruitspeed = 1.5f;
    float eatTimer;
    public Player playerscript;
   // public FruitProperties FP;
    //private GameObject absorbedFruit = null;
    private GameObject[] absorbedFruit = new GameObject[1];
    
    public Collider2D bob;

    //ParticleSystem.MainModule main = consume[i].main;
    public ParticleSystem consume;

    // Use this for initialization
    void Awake()
    {
        //CircleCollider2D cc;
        //cc = gameObject.AddComponent<CircleCollider2D>();
    }


    void Start () {
       
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Resource>().isFruit == true && absorbedFruit[0] == null )
        {
            absorbedFruit[0] = coll.gameObject;
        }
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
       if (colli.gameObject.GetComponent<Resource>().isFruit == true && colli.gameObject == absorbedFruit[0])
        {
            playerscript.publichealth = Mathf.Clamp(playerscript.publichealth, 0, playerscript.StartHealth);
            //health = FruitProperties.publicHealth;
            playerscript.publichunger = playerscript.publichunger + colli.gameObject.GetComponent<FruitProperties>().HungerAmount;
            playerscript.publichealth = playerscript.publichealth + colli.gameObject.GetComponent<FruitProperties>().HealthAmount;
           
           playerscript.publichealth = Mathf.Clamp(playerscript.publichealth, 0, playerscript.StartHealth); // same line not sure if it goes after or before
            if (playerscript.mvtSpd > 0.3f)
            {
                playerscript.mvtSpd = playerscript.mvtSpd + colli.gameObject.GetComponent<FruitProperties>().SpeedPropety;
            }
            Destroy(colli.gameObject);
            absorbedFruit[0] = null;


            //screen flash colors

           
            if (colli.gameObject.GetComponent<FruitProperties>().HungerAmount > colli.gameObject.GetComponent<FruitProperties>().HealthAmount && colli.gameObject.GetComponent<FruitProperties>().HungerAmount > colli.gameObject.GetComponent<FruitProperties>().SpeedPropety)
            {
                playerscript.EflashR = 255;
                playerscript.EflashG = 255;
                playerscript.EflashB = 0;

            }

            if (colli.gameObject.GetComponent<FruitProperties>().HealthAmount > colli.gameObject.GetComponent<FruitProperties>().HungerAmount && colli.gameObject.GetComponent<FruitProperties>().HealthAmount > colli.gameObject.GetComponent<FruitProperties>().SpeedPropety)
            {
                playerscript.EflashR = 0;
                playerscript.EflashG = 255;
                playerscript.EflashB = 0;

            }

            if (colli.gameObject.GetComponent<FruitProperties>().SpeedPropety > colli.gameObject.GetComponent<FruitProperties>().HungerAmount && colli.gameObject.GetComponent<FruitProperties>().SpeedPropety > colli.gameObject.GetComponent<FruitProperties>().HealthAmount)
            {
                playerscript.EflashR = 0;
                playerscript.EflashG = 0;
                playerscript.EflashB = 255;

            }

            if (colli.gameObject.GetComponent<FruitProperties>().HealthAmount <= 0)
            {
                playerscript.EflashR = 255;
                playerscript.EflashG = 0;
                playerscript.EflashB = 0;
                playerscript.badnesstimerhealth = 20f;

            }

            if (colli.gameObject.GetComponent<FruitProperties>().HungerAmount <= 0)
            {

                playerscript.badnesstimerhunger = 20f;
            }

            if (colli.gameObject.GetComponent<FruitProperties>().SpeedPropety <= 0)
            {

                playerscript.badnesstimerspeed = 20f;
            }

            playerscript.StartCoroutine(playerscript.FadeImage(true));
        }
    }

    // Update is called once per frame
    void Update () {

        //effectflash.color = new Color(EflashR, EflashG, EflashB, EflashA);

        if (playerscript.mvtSpd < 0.3)
        {
            playerscript.mvtSpd = 0.3f;
        }
        ParticleSystem.MainModule main = consume.main;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            consume.Play();
            main.loop = true;
            bob.enabled = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (absorbedFruit[0] != null && Vector3.Distance(transform.position, absorbedFruit[0].transform.position) < 1.5f)
            {
                Debug.Log(Vector3.Distance(transform.position, absorbedFruit[0].transform.position));
                Debug.Log(absorbedFruit[0]);
                absorbedFruit[0].transform.position = Vector3.MoveTowards(absorbedFruit[0].transform.position, player.position, fruitspeed * Time.deltaTime);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            main.loop = false;
            consume.Stop();
            bob.enabled = false;
            absorbedFruit[0] = null;
        }

    }
}
