using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour { //The Player should be tagged as player and have the player layermask

    public static Player pc;
    public Text healthtext;
    public int health;
    public static int publichealth = 30; //Remove this, use getHit instead of editing a static variable
    bool alive = true;

    Rigidbody2D rb;

    //Controls how fast the player moves.
    public float mvtSpd = 5;

    public void Awake()
    {
        if (pc == null)
        {
            DontDestroyOnLoad(gameObject);
            pc = this;
        }
        else if (pc != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        health = publichealth;
        healthtext.text = health.ToString();
        if (alive) //Make sure the player cannot move if they're out of health
        {
            movePC();
          //  healthtext.text = health.ToString();
        }
	}

    //As the name says, this function will move the player character around. Easy.
    public void movePC()
    {
        rb.velocity = Vector2.zero;

        bool tryUp = Input.GetKey(KeyCode.W);
        bool tryDown = Input.GetKey(KeyCode.S);
        bool tryLeft = Input.GetKey(KeyCode.A);
        bool tryRight = Input.GetKey(KeyCode.D);

        Vector2 mvtDir = Vector2.zero;
        if (tryUp)
        {
            mvtDir += Vector2.up;
        }
        if (tryDown)
        {
            mvtDir += Vector2.down;
        }
        if (tryLeft)
        {
            mvtDir += Vector2.left;
        }
        if (tryRight)
        {
            mvtDir += Vector2.right;
        }
        mvtDir.Normalize();
        rb.velocity = new Vector3(mvtDir.x * Time.deltaTime * mvtSpd * 75, mvtDir.y * Time.deltaTime * mvtSpd * 75);
    }

    public void getHit(int damage)
    {
        Debug.Log("Took Damage");
        health -= damage; //Update once we get actual health working
        publichealth -= damage;
        if(health <= 0)
        {
            alive = false; //If health runs out, the player dies
        }
    }
}
