using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sharkAttackText : MonoBehaviour
{
    float counter;
    float secondCounter;
    public float waitTime;
    Text sharkText;
    public float distanceToShark; //measures the distance between player and shark
    public GameObject player;
    public GameObject shark;
    // Start is called before the first frame update
    void Start()
    {
        sharkText = GetComponent<Text>();
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //keep calculating the distance between the two objects
        distanceToShark = Vector2.Distance(player.transform.position, shark.transform.position);
        if (distanceToShark < 10)
        {
            showSharkAttack();
        }
        else
        {
            //disables the text
            sharkText.enabled = false;
        }
    }

    void showSharkAttack()
    {
        
        //makes text flash on and off
        if(counter > waitTime)
        {
            //disables the text
            sharkText.enabled = false;
            secondCounter++;
            //checks second counter
            if(secondCounter > 60)
            {
                //reset counters
                counter = 0;
                secondCounter = 0;
            }
        }
        //else count up
        else 
        {
            //show text to warn off attack
            sharkText.enabled = true;
            counter++;
        }
        

    }
}
