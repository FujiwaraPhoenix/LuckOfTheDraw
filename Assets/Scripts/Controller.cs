using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    //Makes sure that there is only one Controller in the scene at any given point in time.
    public static Controller Instance;
    public Text winText;
    public bool bossBeaten;

    public GameObject winbanner;

    //Do not touch this!
    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
		if (bossBeaten)
        {

            winbanner.gameObject.SetActive(true);
            //winText.gameObject.SetActive(true);
        }
        else
        {

            winbanner.gameObject.SetActive(false);
            winText.gameObject.SetActive(false);
        }

	}
}
