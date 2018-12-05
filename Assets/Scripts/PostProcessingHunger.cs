using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingHunger : MonoBehaviour {
    public Player player;
    public float vignetteamount = 0f;
    public PostProcessingProfile PPP;


   // VignetteModel vignette = null;
 
       
	// Use this for initialization
	void Start () {

        vignetteamount = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {

        VignetteModel.Settings vignetteSettings = PPP.vignette.settings;
        vignetteSettings.intensity = vignetteamount;

        if (player.publichunger <= 0f && vignetteamount < 1)
        {
            vignetteamount = vignetteamount + 0.00060f;
        }

        if (player.publichunger > 0f)
        {
            vignetteamount = 0f;
        }

        vignetteSettings.intensity = vignetteamount;
        PPP.vignette.settings = vignetteSettings;

    }
}
