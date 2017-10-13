using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    GameLevel activeLevel;

	// Use this for initialization
	void Start ()
    {
        // __Managers should never be destroyed
        DontDestroyOnLoad(gameObject);
	}

    // Handle level loading
    public void LoadLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }

    // Update score and handle the update functionality of it
    public void AddScore(int points)
    {
        score = score + points;

        // Don't do into negative when we subtract score
        if (score < 0)
            score = 0;

        // Am I even in the Game scene?
        if (!activeLevel)
        {
            if (GameObject.Find("_LevelManager").GetComponent<GameLevel>())
                activeLevel = GameObject.Find("_LevelManager").GetComponent<GameLevel>();
        }

        // Send request to update score
        if (activeLevel)
            activeLevel.UpdateScore(score);
    }
}
