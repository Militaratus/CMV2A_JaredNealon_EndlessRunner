using UnityEngine;

public class Wall : MonoBehaviour
{
    GameManager managerGame;

    // Use this for initialization
    void Start()
    {
        managerGame = GameObject.Find("__Managers").GetComponent<GameManager>();
    }

    // Handle the wall hugging procedure
    public void WallKiss()
    {
        GetComponent<AudioSource>().Play();

        // If not in test mode, subtract score
        if (managerGame)
            managerGame.AddScore(-250);
    }
}
