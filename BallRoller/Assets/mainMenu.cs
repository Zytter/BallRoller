using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    //Debug values
    public int debugLevel;
    public float debugPoints;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMemValues()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        debugLevel = data.Level;
        debugPoints = data.Points;

        Debug.Log("Values in memory: Level " + debugLevel + " Points " + debugPoints);
    }

    public void LoadLevel ()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManagement.LevelID = data.Level;
        SceneManagement.globalPlayerPoints = data.Points;

        SceneManagement.loadLevelFromMemory();


    }
}
