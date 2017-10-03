using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLevel : BaseLevel
{
    // Use this for initialization
    internal override void LevelStart()
    {

    }

    // Update is called once per frame
    internal override void LevelUpdate()
    {

    }

    public void PlayGame()
    {
        managerGame.LoadLevel("Transition");
    }
}
