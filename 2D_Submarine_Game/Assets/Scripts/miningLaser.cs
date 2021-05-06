using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miningLaser : MonoBehaviour
{
    //sound
    public AudioSource laserBeam;
    //transforms
    public Transform laserFirePoint; //starting point of lazer
    public LineRenderer m_lineRenderer; //line renderer reference
    Transform m_transform;
    public int mySortingLayer; //sorts when to draw line on top of sprites
    public GameObject laserParticle;//laser effect for end of laser
    public GameObject laserParent;
    //blood effect for shark
    public GameObject bloodSplatter;
    bool hitEnemy;
    Vector3 mousePos; //get position of mouse
    //bool for sound
    bool soundPlaying;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        //update mouse position constantly
        mousePos = Input.mousePosition; //get position of mouse
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); //converts mouse position
        
        if (Input.GetMouseButton(0))//press left mouse button to shoot laser
        {
            if (soundPlaying == false)
            {
                //play sound
                laserBeam.Play(0);
                soundPlaying = true;
            }
            m_lineRenderer.enabled = true;
            ShootLaser();
        }
        else
        {
            //play sound
            laserBeam.Stop();
            soundPlaying = false;
            m_lineRenderer.enabled = false;//turns off laser if space is not held
        }
        gunRotation();//rotates the laser
    }


    //shoot laser function
    void ShootLaser()
    {
        //uses fuel for laser
        GetComponentInParent<PlayerController>().fuel--;

        if(Physics2D.Raycast(m_transform.position, mousePos))
        {
            //check for raycast hit
            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            if (hit)
            {
                //draw laser to hit point
                drawLaser(laserFirePoint.position, hit.point);
                if(hit.collider.gameObject.name == "Enemy")
                {
                    hitEnemy = true;
                }
                else
                {
                    hitEnemy = false;
                }
                //check what was hit and if we can use send message
                if (hit.collider.gameObject.name == "Enemy" || hit.collider.gameObject.tag == "miningRocks")
                {
                    hit.transform.SendMessage("HitByLaser", hit);
                }


            }
        }
        //if there is no hit still draw laser
        else
        {
            drawLaser(laserFirePoint.position, laserFirePoint.transform.right * 50f);
        }
    }
    
    //function to draw mining laser
    void drawLaser(Vector2 startPos, Vector2 endPos )
    {
        

        //positions
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
        m_lineRenderer.SetWidth(0.08f/2, 0.08f/2);
        
        if(hitEnemy)
        {
            Instantiate(bloodSplatter, endPos, Quaternion.identity);

        }
        else
        Instantiate(laserParticle, endPos, Quaternion.identity);

    }

    //rotate direction of gun toward mouse
    void gunRotation()
    {
        
        //points towards mouse
        Vector2 direc = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        laserParent.transform.right = direc; //moves gun towards mouse
        
    }    

}
