using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Ballshoot.isLevelFinished)
        {
            mainUI.SetActive(false);
            winUI.SetActive(true);
        } else
        {
            mainUI.SetActive(true);
            winUI.SetActive(false);
        }

    }
}
