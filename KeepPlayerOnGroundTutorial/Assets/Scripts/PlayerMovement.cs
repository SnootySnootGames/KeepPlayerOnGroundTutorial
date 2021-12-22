using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//need this library to access the input system features, such as InputValue
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //used to store the player input value, stores and x (left/right) and y (up/down) value
    private Vector2 playerInputValue;

    // Update is called once per frame
    void Update()
    {
        //since movement is not using physics, do not need to run in fixedUpdate!
        MoveLogic();
    }

    //This method is derived from our player input component/input actions
    //We created an action called Move in our Input action asset.
    //The player input component on our player sends meesages via the action names.
    //Example: Move turns to OnMove, if we had an action called Run, it would send a message to OnRun, ect..
    private void OnMove(InputValue value)
    {
        //store player input value in form of vector2. left/right is x values, up/down is y values
        playerInputValue = value.Get<Vector2>();
    }

    private void MoveLogic()
    {
        //Create temp vector2 which stores the x value of player input and 0 for y. 
        Vector2 temp = new Vector2(playerInputValue.x * Time.deltaTime * 5, 0);
        //translate our player transform via the temp vector2 amount
        transform.Translate(temp);
    }
}
