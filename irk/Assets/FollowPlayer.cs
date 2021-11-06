using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float distance = 10f;
  
    void Update () 
    {
        transform.position = new Vector3 (player.position.x, player.position.y, distance);
    }
}
