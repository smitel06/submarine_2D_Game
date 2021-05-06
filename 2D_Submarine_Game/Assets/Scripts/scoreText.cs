using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public Text score;
    public GameObject gameManager;
    int scoreVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreVal = gameManager.GetComponent<GameManager>().score;
        score.text = "Score " + scoreVal;
    }
}
