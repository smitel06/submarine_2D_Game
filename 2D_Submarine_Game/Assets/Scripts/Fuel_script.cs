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
    float fuelPercentage;
    public Text fuelWarning;
    //time stuff
    public float timer;
    public float timetoAdd;
    bool textOn;
    
    // Start is called before the first frame update
    private void Awake()
    {
        timetoAdd = 2f;
        fuelNeedleTransform = transform.Find("FuelNeedle"); //gets the transform of the needle used for the fuel gauge
        fuelGauge = fuelMax;
        fuelMax = player.GetComponent<PlayerController>().maxFuel;
    }


    // Update is called once per frame
    void Update()
    {
        fuelMax = player.GetComponent<PlayerController>().maxFuel;

        fuelValue = player.GetComponent<PlayerController>().fuel;
        fuelGauge = fuelValue;
        
        fuelNeedleTransform.eulerAngles = new Vector3(0, 0, GetFuelRotation());
        fuelNeedleTransform.SetAsLastSibling(); //puts needle on top


        //if fuel low flash warning to player
        fuelPercentage = (100f / fuelMax) * fuelValue;
        if (fuelPercentage < 25)
        {
            fuelWarning.enabled = true;
        }
        else
        {
            fuelWarning.enabled = false;
            
        }
    }

    //works out rotation value for needle
    private float GetFuelRotation()
    {
        float totalAngleSize = ZERO_FUEL_ANGLE - MAX_FUEL_ANGLE;
        float fuelNormalized = fuelGauge / fuelMax;

        return ZERO_FUEL_ANGLE - fuelNormalized * totalAngleSize;
    }
}
