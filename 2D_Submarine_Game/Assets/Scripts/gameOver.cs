using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameOver : MonoBehaviour
{
    public GameObject player;
    public AudioSource main;
    public AudioSource sharkTheme;
    //buttons
    public Button restart;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        //setup buttons
        Button restartButton = restart.GetComponent<Button>();
        restartButton.onClick.AddListener(restartOnClick);

        Button exitButton = exit.GetComponent<Button>();
        exitButton.onClick.AddListener(exitOnClick);

        Time.timeScale = 0;
        main.Stop();
        sharkTheme.Stop();
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void restartOnClick()
    {
        //restarts game
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Debug.Log("restart");
    }

    void exitOnClick()
    {
        //exits game entirely
        Application.Quit();
        Debug.Log("quit");
    }
}
