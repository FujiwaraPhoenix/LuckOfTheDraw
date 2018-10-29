using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour { //Code from one of Nick's earlier projects that we're referencing
    public GameObject Arrow;
    public static Vector3 arrowSize;

    float fireRate;
    float reloadRate = 0f;
    public static float reloadIncrement = 0.3f;

    public static float xRandomNumber;
    public static float x2RandomNumber;
    public GameObject leftBarrel;
    public GameObject rightBarrel;

    public ParticleSystem flamethrower;
    ParticleSystem.MainModule Fmain;
    ParticleSystem.EmissionModule Femission;

    public static float flameSpeed;
    public static float flameSize;
    public static float flameEmission;
    // Use this for initialization
    void Start () {
        flamethrower = GetComponent<ParticleSystem>();
        Fmain = flamethrower.main;
        Femission = flamethrower.emission;
        flamethrower.Stop();
        flameSpeed = flamethrower.main.startSpeed.constant;
        flameSize = flamethrower.main.startSize.constant;
        flameEmission = flamethrower.emission.rateOverTime.constant;
        Fmain.startSpeed = flameSpeed;
        Fmain.startSize = flameSize;
        Femission.rateOverTime = flameEmission;
    }
	
	// Update is called once per frame
	//void Update () {
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (CraftingMechanism.scatterShot == true || CraftingMechanism.basicAttack == true)
    //        {
    //            fireRate += 1f * Time.deltaTime;
    //            if (fireRate > reloadRate)
    //            {
    //                GameObject projectile = (GameObject)Instantiate(Arrow, transform.position, transform.rotation);
    //                projectile.transform.localScale = CraftingMechanism.bulletSize;
    //                xRandomNumber = Random.Range(-5, 8);
    //                x2RandomNumber = Random.Range(0, 5f);
    //                reloadRate += reloadIncrement;
    //            }
    //            if (Input.GetMouseButtonUp(0))
    //            {
    //                reloadRate = 0f;
    //                fireRate = 0f;
    //            }
    //        }
    //        if(CraftingMechanism.shotgun == true)
    //        {
    //            fireRate += 1f * Time.deltaTime;
    //            if (fireRate > reloadRate)
    //            {
    //                GameObject projectileOne = (GameObject)Instantiate(Arrow, transform.position, transform.rotation);
    //                GameObject projectileTwo = (GameObject)Instantiate(Arrow, transform.position, leftBarrel.transform.rotation);
    //                GameObject projectileThree = (GameObject)Instantiate(Arrow, transform.position, rightBarrel.transform.rotation);
  
    //                projectileOne.transform.localScale = CraftingMechanism.bulletSize;
    //                projectileTwo.transform.localScale = CraftingMechanism.bulletSize;
    //                projectileThree.transform.localScale = CraftingMechanism.bulletSize;
    //                reloadRate += reloadIncrement + 0.8f;
    //            }
    //            if (Input.GetMouseButtonUp(0))
    //            {
    //                reloadRate = 0f;
    //                fireRate = 0f;
    //            }
    //        }
    //    }
    //    Fmain.startSpeed = flameSpeed;
    //    Fmain.startSize = flameSize;
    //    Femission.rateOverTime = flameEmission;
    //    if (CraftingMechanism.flamethrower == true)
    //    {
    //        if (Input.GetMouseButton(0))
    //        {
    //            flamethrower.Play();
    //        }
    //        if (Input.GetMouseButtonUp(0))
    //        {
    //            flamethrower.Stop();
    //        }
    //    }

    }
}
