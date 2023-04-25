using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Level;
    public float Points;
    public bool updatingValuesToSave = true;


    void Start()
    {
        SavePlayer();
        
    }

    void Update()
    {
        if (updatingValuesToSave)
        {
            Level = SceneManagement.LevelToSave;
            Points = SceneManagement.globalPlayerPoints;
           // Debug.Log("Detected value" + Level);
        }
    }

    

    public void ResetSave()
    {
        updatingValuesToSave = false;
        Level = 0;
        Points = 0;
        SavePlayer();
        Debug.Log("Overwritten values L: " + Level + " P: " + Points);
        updatingValuesToSave = true;
    }

    public void SavePlayer()
    {

        Debug.Log("Progress saved");
        SaveSystem.SavePlayer(this);
    }
}
//
//
// SAVE METHOD
//
//