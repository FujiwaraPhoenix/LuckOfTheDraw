using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool isFruit; //Whether or not the resource is a fruit, and can thus be eaten.

    //public int modifierNum;

    //The number corresponding to what the resource does when put in a slot
    public int gunModifier;
    public int shotModifier;
    public int effectModifier;

    bool isGone = false; //Whether or not the resource has been picked up and should delete itself
    bool colorSet = false; //Whether the color of the sprite has been set

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
        if(!colorSet) //The first update tick, set its color based on its values
        {
            colorCode();
            colorSet = true;
        }
        if (isGone)
        {
            Destroy(this.gameObject);
        }
    }

    public int pickup(int slot) //When picked up, tell the caller how it affects it the modularity and tell the resource to remove itself, slot corresponds to where it is slotted in
    {
        //isGone = true;
        gameObject.SetActive(false); //Due to issues with references, resources should be deactivated when put into slots and reactivated when dropped back on the ground
        if (slot == 1) //Gun
            return gunModifier;
        else if (slot == 2) //Shot
            return shotModifier;
        else if (slot == 3) //Effect
            return effectModifier;
        return 0; //Error somewhere, returning the default value
    }

    public Sprite giveSprite() //Give a copy of whatever sprite the resource uses
    {
        return self;
    }

    public Color giveColor()
    {
        return sr.color;
    }

    public void eat() //If the resource is a fruit, eat it
    {
        if (isFruit)
        {
            //Do the eat stuff. May need to update the return value
            isGone = true;
        }
    }

    void colorCode()
    {
        float colorR;
        float colorG;
        float colorB;
        if()
    }
}
