using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class shark : MonoBehaviour
{
    public float sharkHealth;
    SpriteRenderer m_spriteRender; //the sprite component
    public AIPath aiPath;
    Color defaultColor;
    bool beingHit;
    float startMaxSpeed;
    

    

    private void Start()
    {
        //assign the renderer
        m_spriteRender = GetComponent<SpriteRenderer>();
        //store the starting colour of the shark
        defaultColor = m_spriteRender.color;   
        //store the current maxspeed of the shark at the start
        startMaxSpeed = this.GetComponent<AIPath>().maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        //kill shark if health is 0
        if(sharkHealth == 0)
        {
            Destroy(gameObject);
        }
        //if not being hit by laser
        if(!beingHit)
        {
            //return speed to what it was
            this.GetComponent<AIPath>().maxSpeed = startMaxSpeed;
            //return color to default 
            m_spriteRender.color = defaultColor;
        }

        //flip the shark if its going left
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 1);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 1);
        }

        
    }

    

        

    //what happens when the shark is hit by the laser
    void HitByLaser()
    {
        this.GetComponent<AIPath>().maxSpeed = startMaxSpeed/2;
        //set being hit to true
        beingHit = true;
        //hurt the shark
        sharkHealth--;
        //set to red when hit by the laser
        m_spriteRender.color = Color.red;
        
    }

    private void LateUpdate()
    {
        //set hit by laser to false
        beingHit = false;
    }

   
    
}
