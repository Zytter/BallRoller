using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //this is a scene index
    public int LevelID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Ballshoot.isLevelFinished)
        {
            Invoke("loadNextLevel", .7f);
        }
    }

    private void loadNextLevel()
    {
        Debug.Log("Level Finished, loading next scene");
        LevelID++;
        SceneManager.LoadScene(LevelID);
        ResetAllValues();
    }

    void ResetAllValues()
    {
        Ballshoot.isLevelFinished = false;
        mainLevelObstacleController.playerPoints = 0;
        Time.timeScale = 1.0f;
    }
}
