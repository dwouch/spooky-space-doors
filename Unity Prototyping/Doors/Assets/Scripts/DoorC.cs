using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorC : MonoBehaviour
{

    public float speed = 2; //speed modifier for Time.Deltatime Lerps
    public float rotatespeed = 0.5f; //speed modifier for rotation Time.deltatime
    public float springy = 40; //same as above, but faster for 'slamming'
    public Transform moveTarget; //transform target to slide to
    private Transform moveOrigin; //will store origin point/

    public bool doorClosed = true; //used to manage door states
    public bool doorOpen = false; //used to detect when the door is fully open
    public bool keyHeld = false; //used to prevent pingponging door
    public bool moveComplete = false;

    // Use this for initialization
    void Start ()
    {
        moveOrigin = this.gameObject.transform; //saves attached game objects current transform.localScale data for later
    }
    // Update is called once per frame
    void Update ()
    {
        
        if (Input.GetKeyUp(KeyCode.Alpha3)) //sets keyHeld flag to false when key is released
            keyHeld = false;

        if (Input.GetKey(KeyCode.Alpha3) && doorClosed == true && keyHeld == false) //If the door is fully closed and has not just finished closing, this opens the door by scaling on the x axis towards the game object center
        {
            transform.position = Vector3.Lerp(moveOrigin.position, moveTarget.position, speed * Time.deltaTime);
            transform.Rotate(0, 0, -1, Space.Self);//negatively modifies only the x axis over time 
            if(transform.position.x > moveTarget.position.x -1) //if the door has scaled enough to reach the far side of the door...
            {
                transform.position = moveTarget.position;
                keyHeld = true; //set HeldFlag to true to prevent door closing without repressing key
                ChangeDoorState(); //invert door based booleans
            }

        }

        if (Input.GetKey(KeyCode.Alpha3) && doorClosed == false && keyHeld == false) //if the door is not closed, closes the door.
        {
            doorOpen = false;
            transform.position = Vector3.Lerp(moveTarget.position, moveOrigin.position, speed * Time.deltaTime);
            transform.Rotate(0, 0, 1, Space.Self);
            if (transform.position.x < moveOrigin.position.x -1) //if the door has scaled enough to reach the far side of the door...
            {
                transform.position = moveOrigin.position;
                keyHeld = true; //set HeldFlag to true to prevent door from opening without repressing key
                ChangeDoorState();//invert door based booleans
            }
        }

        //if (Input.anyKey == false && doorOpen == false && doorClosed == false && transform.localScale.x <= 1) //closed the door quickly if let go before 'latching' open
        //{
        //    //translate back fast
           
        //    if (transform.localScale.x > 1) //if localScale.x exceeds original scale...
        //    {        
        //        ChangeDoorState(); //more of that doorState goodness
        //    }
        //}
    }
    void ChangeDoorState () //toogles the door states
    {
        if (doorClosed) //if true, inverts doorClosed and doorOpen
        {
            doorClosed = false;
            doorOpen = true;
        }
        else
        {
            doorClosed = true;
        }
    }
}
