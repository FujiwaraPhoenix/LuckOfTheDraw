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
        if (coll.gameObject.tag == "Fruit" && absorbedFruit[0] == null )
        {
            absorbedFruit[0] = coll.gameObject;
        }
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
       if (colli.gameObject.tag == "Fruit" && colli.gameObject == absorbedFruit[0])
        {
            playerscript.publichealth = Mathf.Clamp(playerscript.publichealth, 0, playerscript.StartHealth);
            //health = FruitProperties.publicHealth;
            Player.publichunger = Player.publichunger + colli.gameObject.GetComponent<FruitProperties>().HungerAmount;
            playerscript.publichealth = playerscript.publichealth + colli.gameObject.GetComponent<FruitProperties>().HealthAmount;
           
           playerscript.publichealth = Mathf.Clamp(playerscript.publichealth, 0, playerscript.StartHealth); // same line not sure if it goes after or before
            if (playerscript.mvtSpd > 0.3f)
            {
                playerscript.mvtSpd = playerscript.mvtSpd + colli.gameObject.GetComponent<FruitProperties>().SpeedPropety;
            }
            Destroy(colli.gameObject);
            absorbedFruit[0] = null;
      }
    }

    // Update is called once per frame
    void Update () {

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
