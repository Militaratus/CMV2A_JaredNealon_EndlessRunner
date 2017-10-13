using UnityEngine;
using UnityEngine.UI;

public class TransitionLevel : BaseLevel
{
    bool levelLoading = false;
    int complete = 0;
    Text loading;

    // Use this for initialization
    internal override void LevelStart ()
    {
        loading = GameObject.Find("Canvas/Percent").GetComponent<Text>();
    }

    // Update is called once per frame
    internal override void LevelUpdate ()
    {
        // Fake increase of loading % and updating the text
        if (!levelLoading)
        {
            complete++;
            loading.text = complete + "%";
            if (complete >= 100)
            {
                // Stop the fake loading, and actually load the level
                levelLoading = true;
                NextLevel();
            }
        }
    }

    // Load the Game level
    void NextLevel()
    {
        managerGame.LoadLevel("Game");
    }
}
