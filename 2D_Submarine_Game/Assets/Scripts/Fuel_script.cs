using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_script : MonoBehaviour
{
    public GameObject player;//this is the player
    public static float fuelValue = 0;
    //fuel gauge variables
    private Transform fuelNeedleTransform;
    private const float MAX_FUEL_ANGLE = -20;
    private const float ZERO_FUEL_ANGLE = 200;
    public float fuelMax;
    public float fuelGauge;

    
    // Start is called before the first frame update
    private void Awake()
    {
        fuelNeedleTransform = transform.Find("FuelNeedle"); //gets the transform of the needle used for the fuel gauge
        fuelGauge = fuelMax;
        fuelMax = player.GetComponent<PlayerController>().maxFuel;
    }


    // Update is called once per frame
    void Update()
    {
        fuelValue = player.GetComponent<PlayerController>().fuel;
        fuelGauge = fuelValue;
        if(fuelGauge > fuelMax)
        {
            fuelGauge = fuelMax;
        }
        fuelNeedleTransform.eulerAngles = new Vector3(0, 0, GetFuelRotation());
        fuelNeedleTransform.SetAsLastSibling(); //puts needle on top
    }

    //works out rotation value for needle
    private float GetFuelRotation()
    {
        float totalAngleSize = ZERO_FUEL_ANGLE - MAX_FUEL_ANGLE;
        float fuelNormalized = fuelGauge / fuelMax;

        return ZERO_FUEL_ANGLE - fuelNormalized * totalAngleSize;
    }
}
