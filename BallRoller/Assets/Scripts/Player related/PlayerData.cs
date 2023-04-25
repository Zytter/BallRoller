using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int Level;
    public float Points;

    public PlayerData (Player player)
    {
        Level = player.Level;
        Points = player.Points;
    }

  
}
//
//
// DATA IS BEING TRANSFERED HERE
//
//