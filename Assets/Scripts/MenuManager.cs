using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour { //For menu scene management

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void viewInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
