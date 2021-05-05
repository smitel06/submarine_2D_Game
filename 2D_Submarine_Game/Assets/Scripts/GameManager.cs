using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mCam;
    public GameObject researchCentre;
    //shop stuff
    public GameObject shop;
    public float shopDistance;
    public GameObject shopEnter;
    Text shopEnterText;
    bool shopActive;
    string shopMessage;
    //gameoverScreen
    public GameObject gameOverScreen;
    public Text deathText;
    //pause screen
    public Canvas pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        ///text to display to player when near shop
        shopEnterText = shopEnter.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //camera follows player keeping player to centre of screen
        mCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
        
        //change message depending on activity of shop
        if(shopActive == true)
        {
            shopMessage = "Press E to Exit Shop";
        }
        else
        {
            shopMessage = "Press E to Enter Shop";
        }
        shopEnterText.text = shopMessage;

        //how close is the player to the shop
        shopDistance = Vector2.Distance(player.transform.position, researchCentre.transform.position);
        if(shopDistance < 4)
        {
            //show text to enter shop
            shopEnterText.enabled = true;
            //now when e is pressed show the shop
            if (Input.GetKeyDown(KeyCode.E))
            {
                //check if already in shop if so close when e is pressed 
                //else open when e is pressed
                if (shopActive)
                {
                    shop.SetActive(false);
                    shopActive = false;
                }
                else
                {
                    shop.SetActive(true);
                    shopActive = true;
                }
            }

        }
        else
        {
            //deactivate shop and text from showing
            shop.SetActive(false);
            shopEnterText.enabled = false;
        }


        //PAUSE
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseScreen.enabled = true;
            Time.timeScale = 0;
        }



    }

    void GameOver(string message)
    {
        //set error message
        gameOverScreen.SetActive(true);
        
        deathText.text = message;
    }


}


