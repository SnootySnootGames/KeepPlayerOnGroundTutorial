using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Store transform of raycastOrigin object. Used for raycast in GroundCheckMethod()
    [SerializeField] private Transform rayCastOrigin;

    //Store playerFeet transform to allow us to adjust our players position in GroundCheckMethod()
    [SerializeField] private Transform playerFeet;

    //LayerMask used in raycast to make raycast more Performant
    //The raycast will ignore all objects outside of the layermask we select.
    [SerializeField] private LayerMask layerMask;

    //Store the hit information from our raycast, to use to update player's position
    private RaycastHit2D Hit2D;



    // Update is called once per frame
    void Update()
    {
        //Do not need to run in FixedUpdate since this is not physics based. 
        GroundCheckMethod();
    }

    //This method will use a raycast to check below the player. Use this ray hit info to update player position
    private void GroundCheckMethod()
    {
        //store the raycast hit info/The raycast arguements are (origin of ray, direction of ray, length of ray, what layer mask to check against)
        Hit2D = Physics2D.Raycast(rayCastOrigin.position, -Vector2.up, 100f, layerMask);

        //Performant check to see if raycast hit has any data, if so, run the code
        if (Hit2D != false)
        {
            //create temp vector2 to store playerFeet position
            Vector2 temp = playerFeet.position;
            //We get the y position of our raycast hit/ and set the y value of our temp vector2
            temp.y = Hit2D.point.y;
            //we can now directly set our players position by setting it to our temp vector2 value that we adjusted.
            playerFeet.position = temp;
        }
    }
}
