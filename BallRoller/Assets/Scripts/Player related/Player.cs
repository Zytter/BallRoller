using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [System.NonSerialized] public int Level;
   [System.NonSerialized] public float Points;
    public bool updatingValuesToSave = true;
    public bool isThatMainMenu;
   [System.NonSerialized]public bool saveNow;


    void Start()
    {

        if(isThatMainMenu)
        {
            Debug.Log("Not saving progress");
        } else
        {
            SavePlayer();
        }
        
        
    }

    public void Update()
    {
        if (updatingValuesToSave)
        {
             Level = SceneManagement.LevelID;
             Points = SceneManagement.globalPlayerPoints;

            if (saveNow)
            {
                Debug.Log("Progress saved L: " + Level + " P: " + Points);
                SaveSystem.SavePlayer(this);
                saveNow = false;
            }
          
            //Debug.Log("Detected value" + Level);
        }
    }



    private void ResetSave()
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
        saveNow = true; 
    }
}
//
//
// SAVE METHOD
//
//