using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public Button startGame;
    public Button howToPlay;
    public Button exitGame;
    public GameObject howToPlayScreen;
    public GameObject menuScreen;
    //set up return button

    // Start is called before the first frame update
    void Start()
    {
        //set up start menu buttons
        Button startButton = startGame.GetComponent<Button>();
        startButton.onClick.AddListener(startOnClick);

        Button howToPlayButton = howToPlay.GetComponent<Button>();
        howToPlayButton.onClick.AddListener(HowToPlayOnClick);

        Button exitButton = exitGame.GetComponent<Button>();
        exitButton.onClick.AddListener(exitOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startOnClick()
    {
        Debug.Log("start");
        //start the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads main scene
        
    }

    void HowToPlayOnClick()
    {
        howToPlayScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    void exitOnClick()
    {
        //exits game entirely
        Application.Quit();
    }
}
