using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    //This is attached to the player; we parse all information from the InventoryController(ic), so we don't need as many globals here.

    public PlayerBullet pBullet;
    private Vector3 playerPos;

    //Gun information. These are all the base stats for the gun, plus modifiers.

    //Variables to keep track of how the player is shooting and all that.
    public float shotTimer = 0f;

    //Rate of Fire
    public float rof = 3f;
    public float rofMod = 0f;

    //Damage
    public int damage = 1;
    public int dmgMod = 0;

    //Accuracy (Spread)
    public float baseSpread = 5f;
    public float spreadMod = 0f;
    

    //The rest is handled from within the instantiation of each object.



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(generateAngToMouse());
        }
        isPlayerShooting();
	}

    public void isPlayerShooting()
    {
        if (Input.GetMouseButton(0))
        {
            shoot();
        }

        shotTimer -= Time.deltaTime;
    }

    void shoot()
    {
        //
        if (shotTimer <= 0f)
        {
            if (InventoryController.ic.gunIndex != 4)
            {
                PlayerBullet pb = Instantiate(pBullet, transform.position, Quaternion.identity);
                pb.travelDir = generateAngToMouse();
            }
            else
            {
                //Shoot 3.
            }
            //
            shotTimer = rof + rofMod;
        }
    }

    public Vector2 generateAngToMouse()
    {
        Vector2 toMouse = new Vector2(0, 0);
        playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 newLoc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        toMouse = newLoc.normalized;
        return toMouse;
            
    }
}
