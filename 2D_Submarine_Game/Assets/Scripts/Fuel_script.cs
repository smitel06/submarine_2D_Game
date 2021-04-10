using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_script : MonoBehaviour
{
    public GameObject player;//this is the player
    public static float fuelValue = 0;
    Text fuel;
    // Start is called before the first frame update
    void Start()
    {
        fuel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //get fuel value from the playercontroller script
        fuelValue = player.GetComponent<PlayerController>().fuel;
        fuel.text = "FUEL " + fuelValue;
    }
}
