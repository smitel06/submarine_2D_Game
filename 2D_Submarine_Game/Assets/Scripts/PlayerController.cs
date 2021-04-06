using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //public variables to control speed
    public float movementSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
       //controls for movement 
       if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))//move up 
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * Time.deltaTime * movementSpeed);
        }
       else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))///move down
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * Time.deltaTime * movementSpeed * -1); //opposite force for down movement so we use - 1
        }
       else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//move right
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * Time.deltaTime * movementSpeed);
        }
       else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//move left
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * Time.deltaTime * movementSpeed * - 1);
        }
        
    }
}
