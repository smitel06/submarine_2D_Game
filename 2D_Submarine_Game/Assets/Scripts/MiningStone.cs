using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningStone : MonoBehaviour
{
    public float targetScale;
    public float shrinkSpeed;
    public float rockHP;
    public GameObject thisRock;
    public GameObject player;
    public float addResources;
    //sound effect
    public AudioSource rockSmash;
    //gamemanager
    public GameObject gameManager;


    private void Start()
    {
        rockHP = 100;
    }
    //if hit by ray shrink object then destroy
    void HitByLaser()
    {
        //play this sound
        
        if (rockHP <= 0)
        {
            //add to score 100
            gameManager.SendMessage("addToScore", 100);
            //rockbreak sound
            rockSmash.Play(0);
            Destroy(thisRock);
            //adds resources to the players resource bank
            player.SendMessage("addToResources", addResources);
            Debug.Log("destroyed");
        }
        //scale down object
        this.transform.localScale = Vector2.Lerp(this.transform.localScale, new Vector2(targetScale, targetScale), Time.deltaTime * shrinkSpeed);
        rockHP--;

        
    }

    
    }








