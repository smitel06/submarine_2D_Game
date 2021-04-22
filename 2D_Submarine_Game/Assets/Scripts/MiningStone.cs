using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningStone : MonoBehaviour
{
    public float targetScale;
    public float shrinkSpeed;
    float rockHP;
    public GameObject thisRock;
    public GameObject player;
    public float addResources;

    private void Start()
    {
        rockHP = 250;
    }
    //if hit by ray shrink object then destroy
    void HitByLaser()
    {
        
        if (rockHP == 0)
        {
            Destroy(thisRock);
            Debug.Log("destroyed");
            //adds resources to the players resource bank
            player.SendMessage("addToResources", addResources);
        }
        //scale down object
        this.transform.localScale = Vector2.Lerp(this.transform.localScale, new Vector2(targetScale, targetScale), Time.deltaTime * shrinkSpeed);
        rockHP--;
    }





}
