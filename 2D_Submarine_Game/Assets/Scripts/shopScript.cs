using UnityEngine;
using UnityEngine.UI;

public class shopScript : MonoBehaviour
{


    public GameObject gameManager;
    //upgrade levels
    float engineLevel;
    float fuelTankLevel;
    float armorLevel;
    //
    float fuel;
    //button declarations
    public Button refill;
    public Button repair;
    public Button engine;
    public Button fuelTank;
    public Button armor;
    //extra variables
    float resourcePoints;
    public GameObject player;
    float armorValue;
    //errors
    Text ErrorText;
    public GameObject errorObject;
    string errorMessage;
    //timers
    float timeToDissapear;
    float timeCompare;

    // Start is called before the first frame update
    void Start()
    {
        //set levels of parts
        engineLevel = 1;
        fuelTankLevel = 1;
        armorLevel = 1;
        //set text objects
        ErrorText = errorObject.GetComponent<Text>();
        
        timeToDissapear = 2f;
        //set up buttons
        Button refillButton = refill.GetComponent<Button>();
        refillButton.onClick.AddListener(refillOnClick);
        Button repairButton = repair.GetComponent<Button>();
        repairButton.onClick.AddListener(repairOnClick);
        Button engineButton = engine.GetComponent<Button>();
        engineButton.onClick.AddListener(engineOnClick);
        Button fuelButton = fuelTank.GetComponent<Button>();
        fuelButton.onClick.AddListener(fuelTankOnClick);
        Button armorButton = armor.GetComponent<Button>();
        armorButton.onClick.AddListener(armorOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //always update resource points
        resourcePoints = player.GetComponent<PlayerController>().currentResources;
        //update fuel
        fuel = player.GetComponent<PlayerController>().fuel;
        //update armor
        armorValue = player.GetComponent<PlayerController>().armor;

        //if error text enabled wait 2 seconds and delete
        if (ErrorText.enabled == true &&(Time.time >= timeCompare))
        {
            //wait 2 seconds
            ErrorText.enabled = false;
        }
        
    }

    void refillOnClick()
    {
        //when refill button is clicked refill subs fuel levels
        //make sure we have enough currency for the refill
        if (resourcePoints >= 250f)
        {
            float maxFuel = player.GetComponent<PlayerController>().maxFuel;
            //if fuel is lower then max fuel we fill up
            //max fuel is what we use to refill
            if (maxFuel > fuel)
            {
                fuel = player.GetComponent<PlayerController>().fuel = maxFuel;
                player.GetComponent<PlayerController>().currentResources -= 250f;
            }
            else
            {
                errorMessage = "Your tank is already full up!";
                Error();
            }
        }
        else
        {
            errorMessage = "You don't have enough points for that!";
            Error();
        }
    }

    void repairOnClick()
    {
        if (resourcePoints >= 250f)
        {
            float maxArmor = player.GetComponent<PlayerController>().maxArmor;
            //if fuel is lower then max fuel we fill up
            //max fuel is what we use to refill
            if (maxArmor > armorValue)
            {
                player.GetComponent<PlayerController>().armor = maxArmor;
                player.GetComponent<PlayerController>().currentResources -= 250f;
            }
            else
            {
                errorMessage = "Your armor is already perfect!"; 
                Error();
            }
        }
        else
        {
            errorMessage = "You don't have enough points for that!";
            Error();
        }
    }

    void engineOnClick()
    {
        
        if (resourcePoints >= 1500f)
        {
            //check current speed isnt to high
            if (engineLevel < 10)
            {
                engineLevel++;
                //increase speed on upgrade but fuel usage will be a problem
                player.GetComponent<PlayerController>().fuelUsed *= 1.5f;

                player.GetComponent<PlayerController>().movementSpeed += 100;
                player.GetComponent<PlayerController>().currentResources -= 1500f;
                //add to score
                gameManager.SendMessage("addToScore", 1000 * engineLevel);

            }
            else
            {
                errorMessage = "Engine at highest level";
                Error();
            }

        }
        else
        {
            errorMessage = "You don't have enough points for that!";
            Error();
        }
        
    }

    void fuelTankOnClick()
    {
        if (resourcePoints >= 1500f)
        {
            //check current speed isnt to high
            if (fuelTankLevel < 10)
            {
                fuelTankLevel++;
                //increase fuel capacity
                player.GetComponent<PlayerController>().maxFuel = 6500 * fuelTankLevel;
                player.GetComponent<PlayerController>().fuel = player.GetComponent<PlayerController>().maxFuel;
                player.GetComponent<PlayerController>().currentResources -= 1500f;
                //score
                gameManager.SendMessage("addToScore", 1000 * fuelTankLevel);
            }
            else
            {
                errorMessage = "Fuel tank at max capacity!";
                Error();
            }

        }
        else
        {
            errorMessage = "You don't have enough points for that!";
            Error();
        }
    }

    void armorOnClick()
    {
        if (resourcePoints >= 1500f)
        {
            //check current speed isnt to high
            if (armorLevel < 10)
            {
                armorLevel++;
                //increase armor capacity
                player.GetComponent<PlayerController>().maxArmor = 300 * armorLevel;
                player.GetComponent<PlayerController>().armor = player.GetComponent<PlayerController>().maxArmor;
                player.GetComponent<PlayerController>().currentResources -= 1500f;
                //score
                gameManager.SendMessage("addToScore", 1000 * armorLevel);
            }
            else
            {
                errorMessage = "Armor at max capacity!";
                Error();
            }

        }
        else
        {
            errorMessage = "You don't have enough points for that!";
            Error();
        }
    }

    //fuelError for not enough fuel
    void Error()
    {
        
        //display text error
        ErrorText.text = errorMessage;
        ErrorText.enabled = true;
        timeCompare = timeToDissapear + Time.time;
    }

    
}
