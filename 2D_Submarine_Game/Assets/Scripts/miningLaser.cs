using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miningLaser : MonoBehaviour
{
    
    public Transform laserFirePoint; //starting point of lazer
    public LineRenderer m_lineRenderer; //line renderer reference
    Transform m_transform;
    public int mySortingLayer; //sorts when to draw line on top of sprites
    public GameObject laserParticle;//laser effect for end of laser
    public GameObject laserParent;
    Vector3 mousePos; //get position of mouse

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
            m_lineRenderer.enabled = true;
            ShootLaser();
        }
        else
        {
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
                if (hit.distance >= Vector2.Distance(laserFirePoint.position, mousePos))
                {
                    //if the hit is further then the mouse position shoot laser to mouse position
                    drawLaser(laserFirePoint.position, mousePos);
                }
                else
                {
                    //else draw laser to hit point
                    hit.transform.SendMessage("HitByLaser", hit);
                    drawLaser(laserFirePoint.position, hit.point);
                }

            }
        }
        //if there is no hit still draw laser
        else
        {
            drawLaser(laserFirePoint.position, mousePos);
        }
    }
    
    //function to draw mining laser
    void drawLaser(Vector2 startPos, Vector2 endPos )
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
        m_lineRenderer.SetWidth(0.10f, 0.12f);
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
