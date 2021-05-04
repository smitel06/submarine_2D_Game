using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class shark : MonoBehaviour
{
    float sharkStartHealth;
    float sharkHealth;
    SpriteRenderer m_spriteRender; //the sprite component
    //ai path
    public AIPath aiPath;
    Color defaultColor;
    bool beingHitByLaser;
    float startMaxSpeed;
    public float distanceToPlayer;
    public GameObject player;
    bool beforeHit;
    public float attackSpeed;
    public GameObject spawnPoint;
    public float level;
    public GameObject safeZone;
    public float safeDistance;
    //timers
    //timers
    float attackTimer;
    float timeCompare;
    //safe distance
    bool isPlayerSafe;



    private void Start()
    {
        //player in safe asre
        isPlayerSafe = true;

        attackTimer = 3f; // 3 seconds between attacks
        //set health
        sharkStartHealth = 1000;
        sharkHealth = sharkStartHealth;
        //starting values
        level = 1;
        //assign the renderer
        m_spriteRender = GetComponent<SpriteRenderer>();
        //store the starting colour of the shark
        defaultColor = m_spriteRender.color;   
        //store the current maxspeed of the shark at the start
        startMaxSpeed = this.GetComponent<AIPath>().maxSpeed;
        //before hit tells us that shark has not hit player yet
        beforeHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        //kill shark if health is 0
        if(sharkHealth == 0)
        {
            //increase level, movement speed and health
            level++;
            //if level is over 5 level equals 5
            if (level > 10)
                level = 10;
            //respawn 
            this.gameObject.transform.position = spawnPoint.transform.position;
            if(level > 1)
            {
                sharkHealth = sharkStartHealth * level;
                
                //increase speed of shark by one each level
                this.GetComponent<AIPath>().maxSpeed = this.GetComponent<AIPath>().maxSpeed ++;
                startMaxSpeed = this.GetComponent<AIPath>().maxSpeed;
                this.GetComponent<AIDestinationSetter>().changeTarget = false;
            }
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

        //if distance between player and shark is below 10 
        //shark attacks by increasing movement speed
        distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);
        if(distanceToPlayer < 5 && beforeHit)
        {
            //changes movement speed
            this.GetComponent<AIPath>().maxSpeed = startMaxSpeed * attackSpeed;
        }
        //if not being hit by laser
        if(!beingHitByLaser)
        {
            //return color to default 
            m_spriteRender.color = defaultColor;
        }
        //change target before next attack
        if (Time.time >= timeCompare && !beforeHit)
        {
            this.GetComponent<AIDestinationSetter>().changeTarget = false;
            beforeHit = true;
        }
        


        //determine if player is in safe zone
        safeDistance = Vector2.Distance(player.transform.position, safeZone.transform.position);
        //if they are change target
        if (safeDistance < 7)
        {
            this.GetComponent<AIDestinationSetter>().changeTarget = true;
            isPlayerSafe = true;
        }
        else if(safeDistance > 7 && isPlayerSafe == true)
        {
            isPlayerSafe = false;
            this.GetComponent<AIDestinationSetter>().changeTarget = false;
        }



    }


    //what happens when the shark is hit by the laser
    //reduces health
    void HitByLaser()
    {
        //set being hit to true
        beingHitByLaser = true;
        //hurt the shark
        sharkHealth--;
        //set to red when hit by the laser
        m_spriteRender.color = Color.red;
        
    }

    private void LateUpdate()
    {
        //set hit by laser to false
        beingHitByLaser = false;
        //change player back to default color 
        if (distanceToPlayer > 5)
        {
            player.GetComponent<SpriteRenderer>().color = defaultColor;
        }
    }

    //on collision with player 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            this.GetComponent<AIDestinationSetter>().changeTarget = true;

            //set timer
            timeCompare = attackTimer + Time.time;

            //reduce armour of submarine
            player.GetComponent<PlayerController>().armor -= 100;
            //player turns red
            player.GetComponent<SpriteRenderer>().color = Color.red;
            //return shark back to original speed
            this.GetComponent<AIPath>().maxSpeed = startMaxSpeed;
            beforeHit = false;
        }
    }


}
