using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miningLaser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100; //default distance of lazer 
    public Transform laserFirePoint; //starting point of lazer
    public LineRenderer m_lineRenderer; //line renderer reference
    Transform m_transform;
    public int mySortingLayer; //sorts when to draw line on top of sprites
    public GameObject laserParticle;//laser effect for end of laser


    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_lineRenderer.enabled = true;
            ShootLaser();
        }
        else
        {
            m_lineRenderer.enabled = false;//turns off laser if space is not held
        }
    }


    //shoot laser function
    void ShootLaser()
    {
        if(Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            drawLaser(laserFirePoint.position, hit.point);
            if (hit)
            {
                hit.transform.SendMessage("HitByLaser");
            }
        }
        else
        {
            drawLaser(laserFirePoint.position,laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void drawLaser(Vector2 startPos, Vector2 endPos )
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
        m_lineRenderer.SetWidth(0.10f, 0.12f);
        Instantiate(laserParticle, endPos, Quaternion.identity);

    }


}
