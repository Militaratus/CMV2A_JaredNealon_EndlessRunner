using UnityEngine;

public class GameLevel : BaseLevel
{
    GameObject levelText;
    GameObject wallLeft;
    GameObject wallNone;
    GameObject wallMid;
    GameObject wallRight;
    int activeMilestone;
    int activePart;
    TextMesh textScore;
    Transform player;

    // Use this for initialization
    internal override void LevelStart ()
    {
        // Load Resources
        levelText = Resources.Load("Levels/LevelText") as GameObject;
        wallLeft = Resources.Load("Levels/WallLeft") as GameObject;
        wallNone = Resources.Load("Levels/WallNone") as GameObject;
        wallMid = Resources.Load("Levels/WallMid") as GameObject;
        wallRight = Resources.Load("Levels/WallRight") as GameObject;

        // Setup the Level
        BuildInitialLevel();
        player = GameObject.Find("Player").transform;
        textScore = GameObject.Find("Main Camera/Score").GetComponent<TextMesh>();
    }
	
    // Build the initial 10 parts
    void BuildInitialLevel()
    {
        activePart = -9;
        for (int i = 0; i < 10; i++)
        {
            AddPart();
        }
        AddLevelText();
    }

    // Update is called once per frame
    internal override void LevelUpdate ()
    {
        // If the player made enough progress, spawn another part
		if (player.position.z >= (activePart * 20))
        {
            AddPart();
        }

        //  If the player made significant progress, spawn another level text
        if (player.position.z >= (activeMilestone * 1000))
        {
            AddLevelText();
        }
    }

    // Choose a random part
    GameObject RandomPart()
    {
        GameObject newSection;
        int levelSequence = Random.Range(0, 4);
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

        return newSection;
    }

    // Spawn a new part to the world
    void AddPart()
    {
        activePart++;
        GameObject newSection = RandomPart();
        Vector3 levelPlacement = new Vector3(0, 0, (9 * 20) + (activePart * 20));
        Instantiate(newSection, levelPlacement, transform.rotation);
    }

    // Spawn a new level text to the world
    void AddLevelText()
    {
        activeMilestone++;
        Vector3 levelPlacement = new Vector3(0, 0, (activeMilestone * 1000) + 300);
        GameObject nextLevel = Instantiate(levelText, levelPlacement, transform.rotation);
        nextLevel.GetComponent<TextMesh>().text = "LEVEL " + (activeMilestone + 1);
    }

    // Update the text to display the new score
    public void UpdateScore(int score)
    {
        textScore.text = "SCORE:\n" + score;
    }
}
