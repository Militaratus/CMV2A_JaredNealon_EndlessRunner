using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour
{
    // Store References to the Managers for easy access
    internal GameManager managerGame;

	// Use this for initialization
	void Start ()
    {
        GetManagers();
        LevelStart();
    }

    void GetManagers()
    {
        GameObject managers = GameObject.Find("__Managers");

        // This can only happen in testing a scene directly
        if (managers == null)
        {
            GameObject prefabManagers = Resources.Load("__Managers") as GameObject;
            managers = Instantiate(prefabManagers);
        }

        managerGame = managers.GetComponent<GameManager>();
    }

    internal virtual void LevelStart()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        LevelUpdate();
    }

    internal virtual void LevelUpdate()
    {

    }
}
