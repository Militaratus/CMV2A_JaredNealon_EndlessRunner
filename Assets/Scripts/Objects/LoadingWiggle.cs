using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingWiggle : MonoBehaviour {
    bool movingLeft = false;

    // Update is called once per frame
    void Update () {
        WiggleWiggleWiggle();

    }

    // Wiggle Wiggle Wiggle
    void WiggleWiggleWiggle()
    {
        float curRot = transform.rotation.z;
        if (movingLeft)
        {
            curRot = curRot - 0.025f;

            if (curRot < -0.2f)
                movingLeft = false;
        }
        else
        {
            curRot = curRot + 0.025f;

            if (curRot > 0.2f)
                movingLeft = true;
        }

        transform.rotation = new Quaternion(0, 0, curRot, 1);
    }
}
