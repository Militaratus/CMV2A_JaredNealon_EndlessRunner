using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionLevel : BaseLevel {
    Text loading;
    int complete = 0;
    bool levelLoading = false;

	// Use this for initialization
	internal override void LevelStart ()
    {
        loading = GameObject.Find("Canvas/Percent").GetComponent<Text>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // Update is called once per frame
    internal override void LevelUpdate ()
    {
        if (!levelLoading)
        {
            complete++;

            loading.text = complete + "%";

            if (complete >= 97)
            {
                levelLoading = true;
                NextLevel();
            }
        }
    }

    void NextLevel()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
    }
}
