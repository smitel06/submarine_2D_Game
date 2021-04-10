using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables to control speed
    public float movementSpeed;
    //fuel variable
    public float fuel;
    public float fuelUsed;
    public float maxFuel;
    public float currentResources;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
        currentResources = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fuel > 0)
        {
            //controls for movement 
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))//move up 
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * Time.deltaTime * movementSpeed);
                fuel = fuel - fuelUsed;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))///move down
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * Time.deltaTime * movementSpeed * -1); //opposite force for down movement so we use - 1
                fuel = fuel - fuelUsed;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//move right
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * Time.deltaTime * movementSpeed);
                fuel = fuel - fuelUsed;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//move left
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * Time.deltaTime * movementSpeed * -1);
                fuel = fuel - fuelUsed;
            }
        }
        
    }
        public void addToResources(float addValue)
    {
        currentResources +=  addValue;
    }

}
