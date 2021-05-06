using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gameManager;
    //public variables to control speed
    public float movementSpeed;
    //fuel variable
    public float fuel;
    public float fuelUsed;
    public float maxFuel;
    public float currentResources;
    public float armor;
    public float maxArmor;
    bool facingLeft = false;
    //stuff for shark
    public float distanceToShark;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
        currentResources = 0;
        
        //set Armor
        maxArmor = 800;
        armor = maxArmor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If armour = 0 you die
        if(armor == 0)
        {
            Time.timeScale = 0;
            string message = "The shark destroyed you!";
            gameManager.SendMessage("GameOver", message);
            Debug.Log("GameOver");
        }
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
        else
        {
            string message = "Your fuel ran out!";
            //gameover no fuel
            gameManager.SendMessage("GameOver", message);
        }
        
      
    }
        public void addToResources(float addValue)
    {
        currentResources +=  addValue;
    }

}
