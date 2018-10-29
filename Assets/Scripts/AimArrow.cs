using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));



		
	}
}
