using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera follows player keeping player to centre of screen
        mCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);

    }
}
