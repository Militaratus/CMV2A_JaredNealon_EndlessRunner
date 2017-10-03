using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        // __Managers should never be destroyed
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }
}
