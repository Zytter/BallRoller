using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainLevelObstacleController : MonoBehaviour
{

    [SerializeField] private float pointsForThatObstacle = 150; //default value is 150 but its subject to change
    [SerializeField] public static float playerPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPoints += pointsForThatObstacle;

            Debug.Log("Player just hit a reward bounce pad");
            Debug.Log("Player have: " + playerPoints);
        }
    }
}
