using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float playerSpeed = 0.5f;
    bool movingLeft = false;

	// Use this for initialization
	void Start ()
    {
        Debug.Log(transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
        InputManager();
	}

    void FixedUpdate ()
    {
        MoveForward();
        WiggleWiggleWiggle();
    }

    void InputManager()
    {
        if (Input.GetAxis("Horizontal") < 0)
            MoveLeft();

        if (Input.GetAxis("Horizontal") > 0)
            MoveRight();
    }

    void MoveForward()
    {
        // Current Position
        var playerPosition = gameObject.transform.position;

        // Apply speed
        var newPosition = playerPosition.z + playerSpeed;

        // Set new Position
        gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, newPosition);
    }

    public void MoveLeft()
    {
        // Current Position
        var playerPosition = gameObject.transform.position;

        // Apply movement
        var newPosition = playerPosition.x + -playerSpeed;

        if (newPosition < -4)
            newPosition = -4;

        // Set new Position
        gameObject.transform.position = new Vector3(newPosition, playerPosition.y, playerPosition.z);
    }

    public void MoveRight()
    {
        // Current Position
        var playerPosition = gameObject.transform.position;

        // Apply movement
        var newPosition = playerPosition.x + playerSpeed;

        if (newPosition > 4)
            newPosition = 4;

        // Set new Position
        gameObject.transform.position = new Vector3(newPosition, playerPosition.y, playerPosition.z);
    }

    // Wiggle Wiggle Wiggle
    void WiggleWiggleWiggle()
    {
        float curRot = transform.rotation.z;
        if (movingLeft)
        {
            curRot = curRot - 0.05f;

            if (curRot < -0.2f)
                movingLeft = false;
        }
        else
        {
            curRot = curRot + 0.05f;

            if (curRot > 0.2f)
                movingLeft = true;
        }

        transform.rotation = new Quaternion(0, 0, curRot, 1);
    }
}
