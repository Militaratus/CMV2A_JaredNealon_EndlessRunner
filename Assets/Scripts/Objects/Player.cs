using UnityEngine;

public class Player : MonoBehaviour
{
    bool amJumping = false;
    bool movingDown = false;
    bool movingForward = true;
    bool movingLeft = false;
    bool movingRight = false;
    bool movingUp = false;
    bool wiggleLeft = false;
    float cooldownSwitchLane = 0;
    float playerSpeed = 0.5f;
    int lane = 1;
    AudioSource jumpSound;

	// Use this for initialization
	void Start ()
    {
        jumpSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputManager();
        Movement();
        WiggleWiggleWiggle();
    }

    // Handle the input
    void InputManager()
    {
        if (Input.GetAxis("Horizontal") < 0)
            movingLeft = true;
        else
            movingLeft = false;

        if (Input.GetAxis("Horizontal") > 0)
            movingRight = true;
        else
            movingRight = false;

        if (Input.GetAxis("Vertical") > 0 && !movingDown)
            movingUp = true;
        else
            movingUp = false;
    }

    // Handle the movement
    void Movement()
    {
        // Current Position
        Vector3 playerPosition = transform.position;

        // Apply strafing
        float newPositionX = MovementStrafing();

        // Apply jumping
        float newPositionY = MovementJumping();

        // Apply speed
        float newPositionZ = playerPosition.z;
        if (movingForward)
            newPositionZ = newPositionZ + playerSpeed;

        // Set new Position
        transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
        Camera.main.transform.position = new Vector3(0, 4, newPositionZ - 4);
    }

    // Check if I can move and get new position based on input
    float MovementStrafing()
    {
        float newPositionX = transform.position.x;
        if (cooldownSwitchLane < Time.time)
        {
            if (movingLeft || movingRight)
            {
                newPositionX = SwitchLane();

                // Apply cooldown
                cooldownSwitchLane = Time.time + 0.1f;
            }
        }
        return newPositionX;
    }

    // Gets newest lane position based on change
    float SwitchLane()
    {
        float newPosition = 0;

        // Apply lane change
        if (movingLeft && lane > 1) lane--;
        if (movingRight && lane < 5) lane++;

        // Lane position
        if (lane == 1) newPosition = -4;
        if (lane == 2) newPosition = -2;
        if (lane == 3) newPosition = 0;
        if (lane == 4) newPosition = 2;
        if (lane == 5) newPosition = 4;

        return newPosition;
    }

    // Handles the jump functionality
    float MovementJumping()
    {
        // Apply jumping
        float newPositionY = transform.position.y;
        if (movingUp)
        {
            newPositionY = newPositionY + (playerSpeed / 2);
            if (newPositionY > 4.0f)
            {
                newPositionY = 4.0f;
                movingDown = true;
            }

            // Play Jump sound
            if (!amJumping)
            {
                jumpSound.Play();
                amJumping = true;
            }
        }
        else if (newPositionY > 0.5f)
            movingDown = true;

        // Apply falling
        if (movingDown)
        {
            newPositionY = newPositionY + (-playerSpeed / 2);
            if (newPositionY < 0.5f)
            {
                newPositionY = 0.5f;
                movingDown = false;
                amJumping = false;
            }
        }
        return newPositionY;
    }

    // Make the character go Wiggle Wiggle Wiggle
    void WiggleWiggleWiggle()
    {
        float curRot = transform.rotation.z;
        if (wiggleLeft)
        {
            curRot = curRot - 0.05f;

            if (curRot < -0.2f)
                wiggleLeft = false;
        }
        else
        {
            curRot = curRot + 0.05f;

            if (curRot > 0.2f)
                wiggleLeft = true;
        }
        transform.rotation = new Quaternion(0, 0, curRot, 1);
    }

    // What happens if I hit an object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            movingForward = false;
            other.GetComponent<Wall>().WallKiss();
        }
        
        if (other.tag == "Pickup")
            other.GetComponent<Pickup>().Collect();
            
    }

    // Check to see if I stopped hugging the wall
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
            movingForward = true;
    }
}
