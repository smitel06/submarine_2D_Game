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
    bool facingLeft = false;
    //stuff for shark
    public float distanceToShark;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
        currentResources = 0;
        //get scale so we can flip player
        
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
                if (facingLeft)//turns sprite to the right
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    facingLeft = false;
                }
                GetComponent<Rigidbody2D>().AddForce(transform.right * Time.deltaTime * movementSpeed);
                fuel = fuel - fuelUsed;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//move left
            {
                if (facingLeft == false)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    facingLeft = true;
                }
                GetComponent<Rigidbody2D>().AddForce(transform.right * Time.deltaTime * movementSpeed * -1);
                fuel = fuel - fuelUsed;
            }
        }
        
        //calculate distance to player if below 1.99float thats a hit
        distanceToShark = Vector2.Distance(enemy.transform.position, this.transform.position);
            if(distanceToShark< 1.8)
            {
                Debug.Log("hit!");
            }
    }
        public void addToResources(float addValue)
    {
        currentResources +=  addValue;
    }

}
