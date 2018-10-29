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
    GameObject absorbedFruit = null;
    
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
        Debug.Log(absorbedFruit);
        if (coll.tag == "Fruit")
        {
            absorbedFruit = coll.gameObject;
            Debug.Log(absorbedFruit);
            if (absorbedFruit != null)
            {
                ImAFruit.moving = true;
                absorbedFruit.transform.position = Vector3.MoveTowards(absorbedFruit.transform.position, player.position, fruitspeed * Time.deltaTime);
                Debug.Log(absorbedFruit);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
       if (colli.gameObject.tag == "Fruit")
        {
            health = FruitProperties.publicHealth;
            Player.publichunger = Player.publichunger + FruitProperties.publicHunger;
            Player.publichealth = Player.publichealth + FruitProperties.publicHealth;
            Destroy(colli.gameObject);
            absorbedFruit = null;
      }
    }

    // Update is called once per frame
    void Update () {

        
        ParticleSystem.MainModule main = consume.main;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            consume.Play();
            main.loop = true;
            bob.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            main.loop = false;
            consume.Stop();
            bob.enabled = false;
            absorbedFruit = null;
        }

    }
}
