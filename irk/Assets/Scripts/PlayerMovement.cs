using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float speed = 40f;

    private float hMovement = 0f;
    private bool isJumping = false;

    void Update()
    {
        hMovement = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", hMovement);

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(hMovement * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}
