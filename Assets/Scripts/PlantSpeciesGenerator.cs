using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpeciesGenerator : MonoBehaviour {
    
    public EdiblePlant baseplant;
    public int listLength = 3;

    Vector3 plantSpawn;

    //For Jack: Please fill up the generator with plant sprites. Thanks.
    public Sprite[] spriteList = new Sprite[7];

	// Use this for initialization
	void Start () {
        generateSpecies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //At minimum, one species must recover hunger.
    public void generateSpecies()
    {
        Controller.Instance.speciesList = new EdiblePlant[listLength];
        for (int i = 0; i < Controller.Instance.speciesList.Length; i++) {
            EdiblePlant e = Instantiate (baseplant, transform.position, Quaternion.identity);
            e.healthHealed = Random.Range(-10, 10);
            e.hungerRecovered = Random.Range(-10, 10);
            int randomVal = Random.Range(0, 8);
            switch (randomVal)
            {
                case 0:
                    e.pE = EdiblePlant.possibleEffects.None;
                    break;
                case 1:
                    e.pE = EdiblePlant.possibleEffects.Poisoned;
                    break;
                case 2:
                    e.pE = EdiblePlant.possibleEffects.Paralyzed;
                    break;
                case 3:
                    e.pE = EdiblePlant.possibleEffects.Speedy;
                    break;
                case 4:
                    e.pE = EdiblePlant.possibleEffects.Slowed;
                    break;
                case 5:
                    e.pE = EdiblePlant.possibleEffects.Confused;
                    break;
                case 6:
                    e.pE = EdiblePlant.possibleEffects.Drunk;
                    break;
                case 7:
                    e.pE = EdiblePlant.possibleEffects.Hungry;
                    break;
            }
            e.spr.sprite = spriteList[Random.Range(0, spriteList.Length)];
            Controller.Instance.speciesList[i] = e;
        }
        checkSpecies();
    }

    public void checkSpecies()
    {
        bool vetted = false;
        bool vetted1 = false;
        for (int i = 0; i < Controller.Instance.speciesList.Length; i++)
        {
            if (!vetted)
            {
                if (Controller.Instance.speciesList[i].hungerRecovered > 5)
                {
                    vetted = true;
                }
            }
            if (!vetted1)
            {
                if (Controller.Instance.speciesList[i].healthHealed > 5)
                {
                    vetted1 = true;
                }
            }
        }
        if (!vetted)
        {
            int chosenPlant = Random.Range(0, 3);
            Controller.Instance.speciesList[chosenPlant].hungerRecovered = Random.Range(5, 10);
        }

        if (!vetted1)
        {
            int chosenPlant = Random.Range(0, 3);
            Controller.Instance.speciesList[chosenPlant].healthHealed = Random.Range(5, 10);
        }
    }
}
