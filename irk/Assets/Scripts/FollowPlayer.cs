using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float distance = 10f;
  
    void Update () 
    {
        float newX = player.position.x;
        float newY = player.position.y;
        if(newX < -0.5) newX = -0.5f;
        if(newY < -0.5) newY = -1.5f;
        transform.position = new Vector3 (newX, newY, distance);
    }
}
