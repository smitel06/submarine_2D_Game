using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pauseGame : MonoBehaviour
{
    public Canvas pauseScreen;
    public Button resume;
    public Button restart;
    public Button exit;
    
    // Start is called before the first frame update
    void Start()
    {
        //set up buttons
        
Button resumeButton = resume.GetComponent<Button>();
        resumeButton.onClick.AddListener(resumeOnClick);

        Button restartButton = restart.GetComponent<Button>();
        restartButton.onClick.AddListener(restartOnClick);

        Button exitButton = exit.GetComponent<Button>();
        exitButton.onClick.AddListener(exitOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resumeOnClick()
    {
        //resumes game
        Time.timeScale = 1;

        pauseScreen.enabled = false;
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
