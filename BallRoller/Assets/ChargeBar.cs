using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{

    private const float MAX_CHARGE = 100f;
    public float charge = MAX_CHARGE;

    private Image chargeBar;


    // Start is called before the first frame update
    void Start()
    {
        chargeBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        chargeBar.fillAmount = (Ballshoot.actualForceValue * 10) / MAX_CHARGE;
    }
}
