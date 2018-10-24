using System.Collections;
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
    int gunIndex = 0;
    int shotIndex = 0;
    int effectIndex = 0;

    //The images of the resources in the respective slots
    public Image gunImage;
    public Image shotImage;
    public Image effectImage;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            pressOne = true;
            pressTwo = false;
            pressThree = false;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            pressOne = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pressOne = false;
            pressTwo = true;
            pressThree = false;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            pressTwo = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pressOne = false;
            pressTwo = false;
            pressThree = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            pressThree = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("In a trigger");
        if(cooldown <= 0 && collision.tag == "Resource") //If the player is over the triggerbox of a resource
        {
            Debug.Log("Trigger is resource");
            //Depending on what key the player presses, take the resource and input it into a modularity slot
            //If the player already has a resource in that slot, drop the previous resource on the ground
            //Update the references for what resource is in the slot, the modularity instance, and the ui sprite
            //Set the cooldown to .5 seconds

            Resource r = collision.GetComponent<Resource>();
            if(pressOne)
            {
                Debug.Log("Taking Action");
                if(haveGun)
                {
                    //Instantiate(gunResource, transform.position, Quaternion.identity);
                    gunResource.SetActive(true);
                    gunResource.transform.position = transform.position;
                }
                gunResource = r.gameObject;
                gunIndex = r.pickup();
                gunImage.sprite = r.giveSprite();
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
                shotIndex = r.pickup();
                shotImage.sprite = r.giveSprite();
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
                effectIndex = r.pickup();
                effectImage.sprite = r.giveSprite();
                haveEffect = true;
                cooldown = 0.5f;
            }
        }
    }
}
