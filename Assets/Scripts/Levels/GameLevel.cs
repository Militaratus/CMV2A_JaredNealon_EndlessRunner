using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : BaseLevel
{

	// Use this for initialization
	internal override void LevelStart ()
    {
        BuildLevel();

    }
	
    void BuildLevel()
    {
        // Load Resources
        GameObject wallNone = Resources.Load("Levels/WallNone") as GameObject;
        GameObject wallLeft = Resources.Load("Levels/WallLeft") as GameObject;
        GameObject wallMid = Resources.Load("Levels/WallMid") as GameObject;
        GameObject wallRight = Resources.Load("Levels/WallRight") as GameObject;

        // Set Level Length and other neccessary variables
        int LevelLength = 60;
        int levelSequence = 0;
        Vector3 levelPlacement;
        GameObject newSection;

        for (int i = 0; i < LevelLength; i++)
        {
            levelSequence = Random.Range(0, 4);
            switch (levelSequence)
            {
                case 0:
                    newSection = wallNone; break;
                case 1:
                    newSection = wallLeft; break;
                case 2:
                    newSection = wallMid; break;
                case 3:
                    newSection = wallRight; break;
                default:
                    newSection = wallNone; break;
            }

            levelPlacement = new Vector3(0, 0, 20 + (i * 20));
            Instantiate(newSection, levelPlacement, transform.rotation);
        }
    }

    // Update is called once per frame
    internal override void LevelUpdate ()
    {
		
	}
}
