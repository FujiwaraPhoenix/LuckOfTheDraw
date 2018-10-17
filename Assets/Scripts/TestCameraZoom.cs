using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraZoom : MonoBehaviour {

    //Used for testing purposes. In the future, copy this over to the actual camera movement script if we like the effect.

    GameObject cameraTarget; //A gameobject where the camera wants to move to.

    Camera cam;

    float camSize = 5;
    float camSizeTarget; //How big the camera should be when fully zoomed out.
    float camZoomSpeed; //How fast the camera should zoom

    bool moveToTarget = false; //Whether or not the camera should move to the camera target.

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(moveToTarget)
        {
            if(camSize < camSizeTarget)
            {
                camSize += camZoomSpeed;
                cam.orthographicSize = camSize;
            }
            transform.position = (Vector3.Lerp(transform.position, cameraTarget.transform.position, .1f));
        }
	}

    public void activateZoom(GameObject g, float z, float s) //Call this when you want the camera to zoom, pass on what you want the cameraTarget to be and how far out it should zoom.
    {
        cameraTarget = g;
        moveToTarget = true;
        camSizeTarget = z;
        camZoomSpeed = s;
    }
}
