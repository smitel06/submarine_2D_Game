using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilescript : MonoBehaviour
{
    public Tilemap tilemap;
    public int destroyCounter;
    public int counter;
    
    public void HitByLaser(RaycastHit2D hit)//when hit by laser carve away tile
    {
        counter++;
        if (counter == destroyCounter)
        {
            Vector3 hitPosition = Vector3.zero;
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;//gets tileposition from hitpoint
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;//gets tile position from hitpoint
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);//destroys tile 
            counter = 0;
        }

    }
}
