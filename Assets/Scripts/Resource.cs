using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool isFruit; //Whether or not the resource is a fruit, and can thus be eaten.

    public int modifierNum; //The number corresponding to what the resource does when put in a slot

    bool isGone = false; //Whether or not the resource has been picked up and should delete itself

    Sprite self;
    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        self = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGone)
        {
            Destroy(this.gameObject);
        }
    }

    public int pickup() //When picked up, tell the caller how it affects it the modularity and tell the resource to remove itself
    {
        isGone = true;
        return modifierNum;
    }

    public Sprite giveSprite() //Give a copy of whatever sprite the resource uses
    {
        return self;
    }

    public void eat() //If the resource is a fruit, eat it
    {
        if (isFruit)
        {
            //Do the eat stuff. May need to update the return value
            isGone = true;
        }
    }
}
