using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{

    public bool isWinningColl = true;
   // [SerializeField]private GameObject Winscreen;
    


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
            Ballshoot.isLevelFinished = true;
    
        
        }

        if (other.CompareTag("Player") && !isWinningColl)
        {
            Debug.Log("Fail collider has been triggered");
            Destroy(other.gameObject);
            mainLevelObstacleController.playerPoints = 0;
        }

    }

}
