using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Depth_script : MonoBehaviour
{
    public GameObject player;//this is the player
    public GameObject surface; //use island to calculate
    static float depthValueFloat = 0;
    int depthValue;
    Text depth;
    // Start is called before the first frame update
    void Start()
    {
        depth = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //inititalize player and surface then set x axis to 0 so depth only works on y axis
        Vector2 playerPos = player.transform.position;
        Vector2 surfacePos = surface.transform.position;
        playerPos.x = 0;
        surfacePos.x = 0;

        depthValueFloat = Vector2.Distance(playerPos, surfacePos);
        //convert from float to int for display purposes
        depthValue = (int)depthValueFloat;
        //take away 1 so depth starts at 0
        depthValue--;
        depth.text = "Depth: " + depthValue + "M";
    }
}


