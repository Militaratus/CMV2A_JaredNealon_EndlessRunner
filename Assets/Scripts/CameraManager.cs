using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveForward();
    }

    void MoveForward()
    {
        // Current Position
        var camPosition = gameObject.transform.position;

        // Apply speed
        var newPosition = camPosition.z + 0.49999999f;

        // Set new Position
        gameObject.transform.position = new Vector3(camPosition.x, camPosition.y, newPosition);
    }
}
