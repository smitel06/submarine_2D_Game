using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class shark : MonoBehaviour
{
    
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        //flip the shark if its going left
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }

        //rotate the sharkf

    }
}
