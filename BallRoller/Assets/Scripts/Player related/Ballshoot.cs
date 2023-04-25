using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballshoot : MonoBehaviour
{
    public Rigidbody ballPrefab;
    public Transform ballSpawn;
    public float minForce = 5f;
    public float maxForce = 25f;
    public float maxChargeTime = 5f;
    public bool isPlayerOnScene;
    public static bool isLevelFinished;
    public static float ChargeBar;
    public static float actualForceValue;

    private float chargeTime = 0f;
    private bool charging = false;

    void Update()
    {
        if (GameObject.Find("playerPrefab(Clone)")!=null)
        {
            //Debug.Log("Player prefab is on scene");
            isPlayerOnScene = true;
        } else
        {
            isPlayerOnScene = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charging = true;
            chargeTime = 0f;
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            actualForceValue = 0;
            
        }

        if (Input.GetKeyUp(KeyCode.Space)&& !isPlayerOnScene && !isLevelFinished)
        {
            charging = false;

            // Calculate the force to apply based on charge time
             float force = Mathf.Lerp(minForce, maxForce, chargeTime / maxChargeTime);

            //actualForceValue = force;

            // Spawn a new ball and apply force
            Rigidbody ballInstance = Instantiate(ballPrefab, ballSpawn.position, ballSpawn.rotation);
            ballInstance.AddForce(ballSpawn.forward * force, ForceMode.Impulse);
        }

        if (charging && !isPlayerOnScene)
        {
            // Increase the charge time
            chargeTime += Time.deltaTime*2;

            // Clamp the charge time to the maximum charge time
            chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);

            actualForceValue = chargeTime;
        }

        if(isPlayerOnScene)
        {
            charging = false;
        }
    }
}