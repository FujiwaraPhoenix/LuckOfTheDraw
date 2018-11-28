﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour { //Resources must have the "Resource" tag, and the ui canvas should have three images for the inventory ui
    public static InventoryController ic;

    //Copies of the resources that were picked up and slotted in, used to instantiate when slotted out
    GameObject gunResource;
    GameObject shotResource;
    GameObject effectResource;

    //Whether or not the respective slot is filled
    bool haveGun = false;
    bool haveShot = false;
    bool haveEffect = false;

    //The numbers used for the inventory slots
    public int gunIndex = 0;
    public int shotIndex = 0;
    public int effectIndex = 0;

    //The images of the resources in the respective slots
    public Image gunImage;
    public Image shotImage;
    public Image effectImage;

    //guns

    public Image RateOfFire;
    public Image Damage;
    public Image Accuracy;
    public Image Multishot;
    public Image Burst;


    // Shots

    public Image Speed;
    public Image Acceleration;
    public Image Range;
    public Image Homing;
    public Image Size;

    //Possible Effect Variables

    public Image DoT;
    public Image AoE;
    public Image Pierce;
    public Image Bounce;
    public Image Slow;

    //WhichPartIsSelected
    public int WhichPart = 0;
    public Image Part1;
    public Image Part2;
    public Image Part3;

    //Workarounds for using input.getKey in a trigger method
    bool pressOne = false;
    bool pressTwo = false;
    bool pressThree = false;

    //Cooldown stuff
    float cooldown = 0;

    public void Awake()
    {
        if (ic == null)
        {
            DontDestroyOnLoad(gameObject);
            ic = this;
        }
        else if (ic != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

        RateOfFire.gameObject.SetActive(false);
      

		
	}
	
	// Update is called once per frame
	void Update () {

        //mousewheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //forward
        {
            WhichPart = WhichPart - 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //backward
        {
            WhichPart = WhichPart + 1;
        }

        if (WhichPart >=4)
        {
            WhichPart = 0;
        }

        if (WhichPart <= -1)
        {
            WhichPart = 3;
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //which part selected

        if (WhichPart == 0)
        {
            Part1.color = Color.white;
            Part2.color = Color.black;
            Part3.color = Color.black;
        }
        if (WhichPart == 1)
        {
            Part1.color = Color.black;
            Part2.color = Color.white;
            Part3.color = Color.black;
        }

        if (WhichPart == 2)
        {
            Part1.color = Color.black;
            Part2.color = Color.black;
            Part3.color = Color.white;
        }

        if (WhichPart == 0 && Input.GetMouseButtonDown(1))
        {
            pressOne = true;
            pressTwo = false;
            pressThree = false;
        }
        //too much time elapsed
        else if (Input.GetMouseButtonUp(1))
        {
            pressOne = false;
            pressTwo = false;
            pressThree = false;
            Debug.Log("Right button is up");
        }
        else if (WhichPart == 1 && Input.GetMouseButtonDown(1))
        {
            pressOne = false;
            pressTwo = true;
            pressThree = false;
        }

      
        else if (WhichPart == 2 && Input.GetMouseButtonDown(1))
        {
            pressOne = false;
            pressTwo = false;
            pressThree = true;
        }

    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("In a trigger");
        if(cooldown <= 0 && collision.tag == "Resource") //If the player is over the triggerbox of a resource
        {
            //Debug.Log("Trigger is resource");
            //Depending on what key the player presses, take the resource and input it into a modularity slot
            //If the player already has a resource in that slot, drop the previous resource on the ground
            //Update the references for what resource is in the slot, the modularity instance, and the ui sprite
            //Set the cooldown to .5 seconds

            Resource r = collision.GetComponent<Resource>();
            if(pressOne)
            {
                //Debug.Log("Taking Action");
                if(haveGun)
                {
                    //Instantiate(gunResource, transform.position, Quaternion.identity);
                    gunResource.SetActive(true);
                    gunResource.transform.position = transform.position;
                }
                gunResource = r.gameObject;
                gunIndex = r.pickup(1);
                switch(gunIndex)
                {
                    case 0: //default

                        RateOfFire.gameObject.SetActive(false);
                        Damage.gameObject.SetActive(false);
                        Accuracy.gameObject.SetActive(false);
                        Multishot.gameObject.SetActive(false);
                        Burst.enabled = false;



                        break;

                    case 2: //fire rate

                        RateOfFire.gameObject.SetActive(true);
                        Damage.gameObject.SetActive(false);
                        Accuracy.gameObject.SetActive(false);
                        Multishot.gameObject.SetActive(false);
                        Burst.gameObject.SetActive(false);

                        break;

                    case 3: //Damage

                        RateOfFire.gameObject.SetActive(false);
                        Damage.gameObject.SetActive(true);
                        Accuracy.gameObject.SetActive(false);
                        Multishot.gameObject.SetActive(false);
                        Burst.gameObject.SetActive(false);

                        break;

                    case 1: //Accuracy

                        RateOfFire.gameObject.SetActive(false);
                        Damage.gameObject.SetActive(false);
                        Accuracy.gameObject.SetActive(true);
                        Multishot.gameObject.SetActive(false);
                        Burst.gameObject.SetActive(false);

                        break;

                    case 4: //Multishot

                        RateOfFire.gameObject.SetActive(false);
                        Damage.gameObject.SetActive(false);
                        Accuracy.gameObject.SetActive(false);
                        Multishot.gameObject.SetActive(true);
                        Burst.gameObject.SetActive(false);

                        break;

                    case 5: //Burst

                        RateOfFire.gameObject.SetActive(false);
                        Damage.gameObject.SetActive(false);
                        Accuracy.gameObject.SetActive(false);
                        Multishot.gameObject.SetActive(false);
                        Burst.gameObject.SetActive(true);

                        break;

                    case 6: //Lifesteal

                        RateOfFire.gameObject.SetActive(false);
                        Damage.gameObject.SetActive(false);
                        Accuracy.gameObject.SetActive(false);
                        Multishot.gameObject.SetActive(false);
                        Burst.gameObject.SetActive(false);
                        //Lifesteal.gameObject.SetActive(true);



                        break;

                }

                //gunImage.sprite = r.giveSprite();
              //  gunImage.color = r.giveColor();
                haveGun = true;
                cooldown = 0.5f;
            }
            else if (pressTwo)
            {
                if (haveShot)
                {
                    //Instantiate(shotResource, transform.position, Quaternion.identity);
                    shotResource.SetActive(true);
                    shotResource.transform.position = transform.position;
                }
                shotResource = r.gameObject;
                shotIndex = r.pickup(2);
                //shotImage.sprite = r.giveSprite();

                switch (shotIndex)
                {
                    case 0: //default

                        Speed.gameObject.SetActive(false);
                        Acceleration.gameObject.SetActive(false);
                        Range.gameObject.SetActive(false);
                        Homing.gameObject.SetActive(false);
                        Size.gameObject.SetActive(false);



                        break;

                    case 3: //Speed

                        Speed.gameObject.SetActive(true);
                        Acceleration.gameObject.SetActive(false);
                        Range.gameObject.SetActive(false);
                        Homing.gameObject.SetActive(false);
                        Size.gameObject.SetActive(false);

                        break;

                    case 2: //Acceleration

                        Speed.gameObject.SetActive(false);
                        Acceleration.gameObject.SetActive(true);
                        Range.gameObject.SetActive(false);
                        Homing.gameObject.SetActive(false);
                        Size.gameObject.SetActive(false);

                        break;

                    case 1: //Range

                        Speed.gameObject.SetActive(false);
                        Acceleration.gameObject.SetActive(false);
                        Range.gameObject.SetActive(true);
                        Homing.gameObject.SetActive(false);
                        Size.gameObject.SetActive(false);

                        break;

                    case 6: //Homing

                        Speed.gameObject.SetActive(false);
                        Acceleration.gameObject.SetActive(false);
                        Range.gameObject.SetActive(false);
                        Homing.gameObject.SetActive(true);
                        Size.gameObject.SetActive(false);

                        break;

                    case 4: //Size

                        Speed.gameObject.SetActive(false);
                        Acceleration.gameObject.SetActive(false);
                        Range.gameObject.SetActive(false);
                        Homing.gameObject.SetActive(false);
                        Size.gameObject.SetActive(true);

                        break;

                    case 5: //Fire Trail

                        Speed.gameObject.SetActive(false);
                        Acceleration.gameObject.SetActive(false);
                        Range.gameObject.SetActive(false);
                        Homing.gameObject.SetActive(false);
                        Size.gameObject.SetActive(false);
                        //FireTrail.gameObject.SetActive(true);



                        break;

                }
               // shotImage.color = r.giveColor();
                haveShot = true;
                cooldown = 0.5f;
            }
            else if (pressThree)
            {
                if (haveEffect)
                {
                    //Instantiate(effectResource, transform.position, Quaternion.identity);
                    effectResource.SetActive(true);
                    effectResource.transform.position = transform.position;
                }
                effectResource = r.gameObject;
                effectIndex = r.pickup(3);
                // effectImage.sprite = r.giveSprite();


                switch (effectIndex)
                {
                    case 0: //default

                        DoT.gameObject.SetActive(false);
                        AoE.gameObject.SetActive(false);
                        Pierce.gameObject.SetActive(false);
                        Bounce.gameObject.SetActive(false);
                        Slow.gameObject.SetActive(false);


                        break;

                    case 3: //DoT

                        DoT.gameObject.SetActive(true);
                        AoE.gameObject.SetActive(false);
                        Pierce.gameObject.SetActive(false);
                        Bounce.gameObject.SetActive(false);
                        Slow.gameObject.SetActive(false);

                        break;

                    case 5: //AoE

                        DoT.gameObject.SetActive(false);
                        AoE.gameObject.SetActive(true);
                        Pierce.gameObject.SetActive(false);
                        Bounce.gameObject.SetActive(false);
                        Slow.gameObject.SetActive(false);

                        break;

                    case 4: //Pierce

                        DoT.gameObject.SetActive(false);
                        AoE.gameObject.SetActive(false);
                        Pierce.gameObject.SetActive(true);
                        Bounce.gameObject.SetActive(false);
                        Slow.gameObject.SetActive(false);

                        break;

                    case 1: //Bounce

                        DoT.gameObject.SetActive(false);
                        AoE.gameObject.SetActive(false);
                        Pierce.gameObject.SetActive(false);
                        Bounce.gameObject.SetActive(true);
                        Slow.gameObject.SetActive(false);

                        break;

                    case 2: //Slow

                        DoT.gameObject.SetActive(false);
                        AoE.gameObject.SetActive(false);
                        Pierce.gameObject.SetActive(false);
                        Bounce.gameObject.SetActive(false);
                        Slow.gameObject.SetActive(true);

                        break;

                    case 6: //Stun

                        DoT.gameObject.SetActive(false);
                        AoE.gameObject.SetActive(false);
                        Pierce.gameObject.SetActive(false);
                        Bounce.gameObject.SetActive(false);
                        Slow.gameObject.SetActive(false);
                        //Stun.gameobject.SetActive(true);


                        break;

                }
                //effectImage.color = r.giveColor();
                haveEffect = true;
                cooldown = 0.5f;
            }
        }
    }
}
