using UnityEngine;

public class DoorA : MonoBehaviour
{
    public float speed = 2; //speed modifier for Time.Deltatime Lerps
    public float springy = 40; //same as above, but faster for 'slamming'
    private Vector3 closedScale; //reference default scale

    public bool doorClosed = true; //used to manage door states
    public bool doorOpen = false; //used to detect when the door is fully open
    public bool keyHeld = false; //used to prevent pingponging door

    // Use this for initialization
    void Start ()
    {
        closedScale = transform.localScale; //saves attached game objects current transform.localScale data for later
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) //sets keyHeld flag to false when key is released
            keyHeld = false;

        if (Input.GetKey(KeyCode.Alpha1) && doorClosed == true && keyHeld == false) //If the door is fully closed and has not just finished closing, this opens the door by scaling on the x axis towards the game object center
        {

            transform.localScale = new Vector3(transform.localScale.x - transform.localScale.x * (speed * Time.deltaTime), transform.localScale.y, transform.localScale.z); //negatively modifies only the x axis over time 
            if (transform.localScale.x <= 0.1) //if the door has scaled enough to reach the far side of the door...
            {
                keyHeld = true; //set HeldFlag to true to prevent door closing without repressing key
                ChangeDoorState(); //invert door based booleans
            }

        }

        if (Input.GetKey(KeyCode.Alpha1) && doorClosed == false && keyHeld == false) //if the door is not closed, closes the door.
        {
            doorOpen = false;
            transform.localScale = new Vector3(transform.localScale.x + transform.localScale.x * (speed * Time.deltaTime), transform.localScale.y, transform.localScale.z); //positively modifies only the x axis over time 
            if (transform.localScale.x >= 1) //if the door has scaled enough to reach the far side of the door...
            {
                keyHeld = true; //set HeldFlag to true to prevent door from opening without repressing key
                ChangeDoorState();//invert door based booleans
            }
        }

        if (Input.anyKey == false && doorOpen == false && doorClosed == false && transform.localScale.x <= 1) //closed the door quickly if let go before 'latching' open
        {
            transform.localScale = new Vector3(transform.localScale.x + transform.localScale.x * (springy * Time.deltaTime), transform.localScale.y, transform.localScale.z); //more of the same shit as above, but faster
            if (transform.localScale.x > 1) //if localScale.x exceeds original scale...
            {
                transform.localScale = closedScale; //...reset to original scale
                ChangeDoorState(); //more of that doorState goodness
            }                       
        }
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

