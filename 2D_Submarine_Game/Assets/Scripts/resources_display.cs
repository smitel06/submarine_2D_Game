using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resources_display : MonoBehaviour
{

   public GameObject player;
   public static float rpValue;
    Text resourcePoints;
    // Start is called before the first frame update
    void Start()
    {
        resourcePoints = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //get rp value from the stone script
        rpValue = player.GetComponent<PlayerController>().currentResources;

        resourcePoints.text = "RP " + rpValue;
    }

    
}

