using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour { //The Player should be tagged as player and have the player layermask

    public static Player pc;
   // public Text healthtext;
  //  public Text hungerText;
   // public Text speedText;
    public float health = 30;
    public float publichealth = 30;
    public float publichunger = 100;
    public float publicspeed = 2;
    bool alive = true;
    public float EflashR = 255;
    public float EflashG = 255;
    public float EflashB = 255;
    public float EflashA = 0;
    public float StartHunger = 100;
    public float invulnTimer = 0;
    public float invulnReset = 1f;

    //UI

    public Image effectflash;
    public Slider HbarSlide;
    public int StartHealth = 30;
    public Transform hungerradial;
    public Transform SpeedChevrons;
    public float badnesstimerhealth = 0; //- frames 
    public float badnesstimerhunger = 0; //- frames 
    public float badnesstimerspeed = 0; //- frames 
    public Image Hbarfill;
    public Color Hbarfillcolorstart;
    public Image SpeedImage;
    public Image HungerImage;
    public Color HungerImageStart;
    public Text loseText;
    //


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
        effectflash.color = new Color(255, 255, 255, 0);
        Hbarfillcolorstart = Hbarfill.color;
        HungerImageStart = HungerImage.color;
        loseText.gameObject.SetActive(false);
    }

    public IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -=Time.deltaTime)
            {
                EflashA = i;
                yield return null;

            }
        }

        else
        {
            for (float i = 0; i <=1; i += Time.deltaTime)
            {
                EflashA = i;
                yield return null;
            }
        }
    }

    // Update is called once per frame
    void Update () {

        if (publichunger <= 0 ) 
        {
            HungerImage.color = Color.red;
            badnesstimerhunger = 20f;
            publichealth = publichealth - 0.006f;
        }

        //flash red ui
        if (badnesstimerhealth > 0)
        {
            badnesstimerhealth = badnesstimerhealth - 1;
            Hbarfill.color = Color.red;
        }
        if (badnesstimerhunger > 0)
        {
            badnesstimerhunger = badnesstimerhunger - 1;
            HungerImage.color = Color.red;
        }
        if (badnesstimerspeed > 0)
        {
            badnesstimerspeed = badnesstimerspeed - 1;
            SpeedImage.color = Color.red;
        }

        if (badnesstimerhealth <= 0)
        {
            Hbarfill.color = Hbarfillcolorstart;
        }

        if (badnesstimerspeed <= 0)
        {
            SpeedImage.color = new Color(255,255,255);
        }

        if (badnesstimerhunger <= 0)
        {
            HungerImage.color = HungerImageStart;
        }

        effectflash.color = new Color(EflashR, EflashG, EflashB, EflashA);
        //speedui
        SpeedChevrons.GetComponent<Image>().fillAmount = mvtSpd / 5;
        //hungerradial
        hungerradial.GetComponent<Image>().fillAmount = publichunger / 100;
        //healthbar
        publichealth = Mathf.Clamp(publichealth, 0, StartHealth);
        HbarSlide.value = publichealth;
        mySpriteRenderer = player1Sprite.GetComponent<SpriteRenderer>();
        gunSpriteRenderer = gunSprite.GetComponent<SpriteRenderer>();
        //speedText.text = mvtSpd.ToString();
        health = publichealth;
        //hungerText.text = publichunger.ToString("F0");
        //healthtext.text = health.ToString();


        publichunger -= 1.0f * Time.deltaTime;
        if (alive) //Make sure the player cannot move if they're out of health
        {
            movePC();
          //  healthtext.text = health.ToString();
        }

        if (!alive) //If the player is dead, say they lost and freeze time
        {
            loseText.gameObject.SetActive(true);
            Time.timeScale = 0;
            this.gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.P)) //Resets the game
        {
            Destroy(this.gameObject, .001f);
            Destroy(Controller.Instance, .001f);
            SceneManager.LoadScene("SampleScene");
        }
        invulnTimer -= Time.deltaTime;
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
            player1Sprite.transform.localScale = new Vector3(-0.5f,0.5f,1);
        }
        if (tryRight)
        {
            mvtDir += Vector2.right;
            player1Sprite.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            gunSpriteRenderer.flipY = false;
        }
        mvtDir.Normalize();
        rb.velocity = new Vector3(mvtDir.x * Time.deltaTime * mvtSpd * 75, mvtDir.y * Time.deltaTime * mvtSpd * 75);
    }

    public void getHit(int damage)
    {

        
            EflashR = 255;
            EflashG = 0;
            EflashB = 0;
        StartCoroutine(FadeImage(true));
        badnesstimerhealth = 20f;
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
        invulnTimer = invulnReset;
    }
}
