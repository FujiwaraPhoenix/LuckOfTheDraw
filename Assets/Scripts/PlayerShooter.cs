using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    //This is attached to the player; we parse all information from the InventoryController(ic), so we don't need as many globals here.

    public PlayerBullet pBullet;
    public GameObject barrel;
    private Vector3 playerPos;

    //The gun, used for feedback
    public AimArrow gunSprite;

    //Gun information. These are all the base stats for the gun, plus modifiers.

    //Variables to keep track of how the player is shooting and all that.
    public float shotTimer = 0f;

    //Rate of Fire
    public float rof = 2f;
    public float rofMod = 0f;
    bool canShoot = true;

    //Damage
    public int damage = 1;
    public int dmgMod = 0;

    //Accuracy (Spread)
    public float baseSpread = 5f;
    public float spreadMod = 0f;

    //Burst
    float burstTimer = 0;
    int burstCount = 0;
    bool inBurst = false;
    

    //The rest is handled from within the instantiation of each object.



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (InventoryController.ic.gunIndex == 1)
        {
            rofMod = -1f;
        }
        else
        {
            rofMod = 0f;
        }
        if (InventoryController.ic.gunIndex == 3)
        {
            spreadMod = -2.5f;
        }
        else
        {
            spreadMod = 0f;
        }

		/*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(generateAngToMouse());
        }*/

        //For the sake of 

        isPlayerShooting();

        if(inBurst && InventoryController.ic.gunIndex == 5) //If the player has burst shots and has shot, fire two more shots afterwards
        {
            if(burstCount >= 3)
            {
                inBurst = false;
            }
            else if(burstTimer >= 0.15f)
            {
                burstTimer = 0;
                burstCount++;
                inBurst = true;
                PlayerBullet pb = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                //pb.travelDir = generateAngToMouse();
                pb.transform.localRotation = gunSprite.transform.localRotation;
                pb.travelDir = pb.transform.right;
                pb.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);
            }
            else
            {
                burstTimer += Time.deltaTime;
            }
        }
	}

    public void isPlayerShooting()
    {
        if (Input.GetMouseButton(0))
        {
            shoot();
        }

        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0f && !canShoot)
        {
            canShoot = true;
            gunSprite.flashColor();
        }
    }

    void shoot()
    {
        //
        if (canShoot)
        {
            canShoot = false;
            if(InventoryController.ic.gunIndex == 4) //Multishot
            {
                /*PlayerBullet pb = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                pb.travelDir = generateAngToMouse();
                PlayerBullet pb1 = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                pb.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);
                //pb1.travelDir = new Vector3(pb.travelDir.x, pb.travelDir.y, 0f) * Quaternion.AngleAxis(15, Vector2.right);
                pb1.travelDir = (Vector2)(Quaternion.Euler(0, 0, 15f) * generateAngToMouse());
                pb1.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);
                PlayerBullet pb2 = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                pb2.travelDir = (Vector2)(Quaternion.Euler(0, 0, -15f) * generateAngToMouse());
                pb2.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);*/

                PlayerBullet pb = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                pb.transform.localRotation = gunSprite.transform.localRotation;
                pb.travelDir = pb.transform.right;
                pb.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);

                PlayerBullet pb1 = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                pb1.transform.localRotation = pb.transform.localRotation;
                pb1.transform.Rotate(Vector3.forward, 15);
                pb1.travelDir = pb1.transform.right;
                pb1.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);

                PlayerBullet pb2 = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                pb2.transform.localRotation = pb.transform.localRotation;
                pb2.transform.Rotate(Vector3.forward, -15);
                pb2.travelDir = pb2.transform.right;
                pb2.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);
            }
            else if (InventoryController.ic.gunIndex == 5) //Burst
            {
                burstTimer = 0;
                burstCount = 1;
                inBurst = true;
                PlayerBullet pb = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                //pb.travelDir = generateAngToMouse();
                pb.transform.localRotation = gunSprite.transform.localRotation;
                pb.travelDir = pb.transform.right;
                pb.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);
            }
            else //Default
            {
                PlayerBullet pb = Instantiate(pBullet, barrel.transform.position, Quaternion.identity);
                //Vector2 tempDir = generateAngToMouse();
                //float angle = ToAng(tempDir);
                //Debug.Log(angle);
                //float actualAngle = Random.Range(angle - (baseSpread + spreadMod), angle + (baseSpread + spreadMod));
                //Debug.Log(actualAngle);
                //pb.travelDir = ToVect(actualAngle).normalized;
                //pb.travelDir = tempDir.normalized;
                pb.transform.localRotation = gunSprite.transform.localRotation;
                pb.travelDir = pb.transform.right;
                pb.setIndices(InventoryController.ic.gunIndex, InventoryController.ic.shotIndex, InventoryController.ic.effectIndex);
            }
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

    public static float ToAng(Vector3 a)
    {
        return Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg;
    }

    public static Vector3 ToVect(float a)
    {
        return new Vector3(Mathf.Cos(a * Mathf.Deg2Rad), Mathf.Sin(a * Mathf.Deg2Rad), 0);
    }
}
