using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashLevel : BaseLevel
{
	// Use this for initialization
	internal override void LevelStart ()
    {
        managerGame.LoadLevel("MainMenu");
	}

    // Update is called once per frame
    internal override void LevelUpdate()
    {
		
	}
}
