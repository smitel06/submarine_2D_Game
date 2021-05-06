using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameWin : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject gameManager;
    public AudioSource winSound;
    bool soundPlaying;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player wins add to score and do score screen 
        //add 25000 to score
        if (collision.gameObject.name == "Player")
        {
            gameManager.SendMessage("addToScore", 25000);
            winScreen.SetActive(true);
            if (soundPlaying == false)
            {
                winSound.Play(0);
                soundPlaying = true;
            }
            //run win screen canvas



        }

    }
}
