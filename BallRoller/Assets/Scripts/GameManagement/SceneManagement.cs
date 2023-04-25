using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //this is a scene index
    public static int LevelID;
    public static float globalPlayerPoints;
    public static int LevelToSave;
    public bool Paused;
    public bool wasFunctionCalled;


    // Start is called before the first frame update
    void Start()
    {
        if (LevelID <= 0)
        {
            LevelID++;
        }

        wasFunctionCalled = false;
    }

    // Update is called once per frame
    void Update()
    {//----------------------------------------------------------------
        if (Ballshoot.isLevelFinished&&!Paused)
        {
            InvokeFixer();
            //Invoke("loadNextLevel", .7f);
        }
    //-----------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Escape)&&!Paused){
            Paused = true;
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.Escape)&&Paused)
        {
            Paused = false;
            unPauseGame();
        }

    }

    public void InvokeFixer()//While Invoke Function (loadNextLevel) was in void Update Level Values were wrong
    {
       
        if (!wasFunctionCalled)
        {
            Invoke("loadNextLevel", .7f);
        }

        wasFunctionCalled = true;

    }

    //Function that pauses the game by using UI controlls
    public void UIPause()
    {
        if (Paused)
        {
            unPauseGame();
        } else
        {
            PauseGame();
        }
    }
    //Pause / unpause
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void unPauseGame() 
    {
        Time.timeScale = 1.0f;
    }

    private void loadNextLevel() //Automatically loads next level after finishing one
    {
        LevelID++;
        Debug.Log("Level Finished, loading next scene with ID " +LevelID);
        
        updateGlobalValues();

        if(LevelID <= 1)
        {
            SceneManager.LoadScene(LevelID + 1);
        }else
        {
            SceneManager.LoadScene(LevelID);
        }
          ResetAllValues();
    }

    public static void loadLevelFromMemory() //Loading level from a save file
    {

        Debug.Log("Loading scene with ID" + LevelID);

        if (LevelID <= 0)
        {
            LevelID++;
        }

        SceneManager.LoadScene(LevelID);
        
    }

    void ResetAllValues() //Reseting all local temp values
    {
        Ballshoot.isLevelFinished = false;
        mainLevelObstacleController.playerPoints = 0;
        Time.timeScale = 1.0f;
    }

    public static void updateGlobalValues() //Updating global values
    {
        globalPlayerPoints += mainLevelObstacleController.playerPoints;
        Debug.Log("Global player points :" + globalPlayerPoints);

       // LevelToSave = LevelID;
        
    }

 
 }


