using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{

    public bool isWinningColl = true;
    


    private float fixedDeltaTime;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }



    // Update is called once per frame
    void Update()
    {

        


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&isWinningColl)
        {
            Debug.Log("Collision Detected, player Won");
            Debug.Log("Player ended up with: " + mainLevelObstacleController.playerPoints+ "points");
            //time scaling
            Time.timeScale = .2f;
            Debug.Log("Time slowdown to .2f has been applied");
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Ballshoot.isLevelFinished = true;
          
    
        
        } else
        {
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }

        if (other.CompareTag("Player") && !isWinningColl)
        {
            Debug.Log("Fail collider has been triggered");
            Destroy(other.gameObject);
           
            mainLevelObstacleController.playerPoints = 0;
        }


    }

}
