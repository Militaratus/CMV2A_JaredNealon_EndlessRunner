using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool collected = false;
    bool hoverUp = false;
    float startingHeight;
    GameManager managerGame;

	// Use this for initialization
	void Start ()
    {
        startingHeight = transform.position.y;
        managerGame = GameObject.Find("__Managers").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Keep enticing the player to collect until it is collected
        if (!collected)
        {
            Hovering();
            Spinning();
        }
    }

    // Move the coin up and down
    void Hovering()
    {
        // Current Position
        Vector3 pickupPosition = transform.position;

        // Hover
        float newPositionY = pickupPosition.y;
        if (hoverUp)
        {
            newPositionY = newPositionY + 0.1f;
            if (newPositionY > (startingHeight + 0.5f))
                hoverUp = false;
        }
        else
        {
            newPositionY = newPositionY - 0.1f;
            if (newPositionY < (startingHeight - 0.5f))
                hoverUp = true;
        }
        transform.position = new Vector3(pickupPosition.x, newPositionY, pickupPosition.z);
    }

    // Spin the coin
    void Spinning()
    {
        float curRot = transform.rotation.y;
        curRot = curRot + 0.05f;

        // If the rotation reaches the negative zero, reset
        if (curRot > 1.045f)
            curRot = 0;

        transform.rotation = new Quaternion(0, curRot, 0, transform.rotation.w);
    }

    // Handle the collection procedure
    public void Collect()
    {
        collected = true;
        GetComponent<AudioSource>().Play();
        transform.GetChild(0).gameObject.SetActive(false);

        // If not in test mode, add score
        if (managerGame)
            managerGame.AddScore(100);
    }
}
