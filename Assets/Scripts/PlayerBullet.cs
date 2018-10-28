using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public Vector3 travelDir;
    public bool isSine = false;
    public int aftereffect = 0;
    public float mvtSpd = 5;
    public int damage = 1;
    public float lifetime = 3;

    int gunIndex;
    int shotIndex;
    int effectIndex;

    float timer = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += travelDir * mvtSpd * Time.deltaTime;

        Debug.Log(Mathf.Cos(timer) + " " + Mathf.Sin(timer));

        if (shotIndex == 2) //If the bullet has acceleration
        {
            mvtSpd += 15 * Time.deltaTime;
        }
        
        if(timer >= lifetime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
	}

    public void setIndices(int g, int s, int e) //Sets the modifiers for the shot when it is shot
    {
        gunIndex = g;
        shotIndex = s;
        effectIndex = e;

        switch(shotIndex)
        {
            case 1:
                mvtSpd = 10;
                break;
            case 2: //Temporary
                mvtSpd = 1;
                break;
        }
    }
}
