using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour //Many thanks to Diego for making this script
{


    public Transform myTarget;

    public float box1width;
    public float box1height;

    public float box2width;
    public float box2height;

    public float box1lerp;




    // Use this for initialization
    void Start()
    {

        transform.position = myTarget.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float myXpos = transform.position.x;
        float myYpos = transform.position.y;

        if (Mathf.Abs(myTarget.position.x - transform.position.x) > box2width / 2)
        {
            float newX = myTarget.position.x - Mathf.Sign(myTarget.position.x - transform.position.x) * box2width / 2;
            myXpos = newX;
        }
        else if (Mathf.Abs(myTarget.position.x - transform.position.x) > box1width / 2)
        {
            float newX = myTarget.position.x - Mathf.Sign(myTarget.position.x - transform.position.x) * box1width / 2;
            myXpos = Mathf.Lerp(myXpos, newX, box1lerp);
        }

        if (Mathf.Abs(myTarget.position.y - transform.position.y) > box2height / 2)
        {
            float newY = myTarget.position.y - Mathf.Sign(myTarget.position.y - transform.position.y) * box2height / 2;
            myYpos = newY;
        }
        else if (Mathf.Abs(myTarget.position.y - transform.position.y) > box1height / 2)
        {
            float newY = myTarget.position.y - Mathf.Sign(myTarget.position.y - transform.position.y) * box1height / 2;
            myYpos = Mathf.Lerp(myYpos, newY, box1lerp);
        }

        transform.position = new Vector3(myXpos, myYpos, -10f);

        if(Input.GetKey(KeyCode.P))
        {
            //Reset
            Destroy(myTarget.gameObject);
            Destroy(Controller.Instance);
            SceneManager.LoadScene("SampleScene");
        }

    }

    /*void OnDrawGizmos()
    {

        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, new Vector3(box2width, box2height, 1f));

        Gizmos.color = Color.grey;
        Gizmos.DrawCube(transform.position, new Vector3(box1width, box1height, 1f));


    }*/
}