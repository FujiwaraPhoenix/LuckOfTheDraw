using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour { //The Player should be tagged as player and have the player layermask

    public static Player pc;
   // public Text healthtext;
  //  public Text hungerText;
    public Text speedText;
    public int health = 30;
    public int publichealth = 30;
    public float publichunger = 100;
    public float publicspeed = 2;
    bool alive = true;
    public float StartHunger = 100;

    //UI

 
    public Slider HbarSlide;
    public int StartHealth = 30;
    public Transform hungerradial;


    private SpriteRenderer mySpriteRenderer;
    private SpriteRenderer gunSpriteRenderer;
    public GameObject player1Sprite;
    public GameObject gunSprite;

    Rigidbody2D rb;


    //Controls how fast the player moves.
    public float mvtSpd = 0.5f;

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
       // mySpriteRenderer = player1Sprite.GetComponent<SpriteRenderer>(); -- this shit can't be in start, that's why movement wasn't working. 
       // gunSpriteRenderer = gunSprite.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update () {
        //hungerradial
        hungerradial.GetComponent<Image>().fillAmount = publichunger / 100;
        //healthbar
        publichealth = Mathf.Clamp(publichealth, 0, StartHealth);
        HbarSlide.value = publichealth;
        mySpriteRenderer = player1Sprite.GetComponent<SpriteRenderer>();
        gunSpriteRenderer = gunSprite.GetComponent<SpriteRenderer>();
        speedText.text = mvtSpd.ToString();
        health = publichealth;
        //hungerText.text = publichunger.ToString("F0");
        //healthtext.text = health.ToString();


        publichunger -= 1.0f * Time.deltaTime;
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
            mySpriteRenderer.flipX = true;
            gunSpriteRenderer.flipY = true;
        }
        if (tryRight)
        {
            mvtDir += Vector2.right;

            gunSpriteRenderer.flipY = false;
        }
        mvtDir.Normalize();
        rb.velocity = new Vector3(mvtDir.x * Time.deltaTime * mvtSpd * 75, mvtDir.y * Time.deltaTime * mvtSpd * 75);
    }

    public void getHit(int damage)
    {
        Debug.Log("Took Damage");
        health = Mathf.Clamp(health,0,StartHealth);
        publichealth = Mathf.Clamp(publichealth, 0, StartHealth);
        health -= damage; //Update once we get actual health working
        publichealth -= damage;
        health = Mathf.Clamp(health, 0, StartHealth);
        publichealth = Mathf.Clamp(publichealth, 0, StartHealth);
        if (health <= 0)
        {
            alive = false; //If health runs out, the player dies
        }
    }
}
