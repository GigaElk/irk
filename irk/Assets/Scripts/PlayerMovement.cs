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
        if(gameObject.transform.position.y < -10)
        {
            Debug.Log("Player Died!");
            Respawn();
        }
        else
        {
            hMovement = Input.GetAxisRaw("Horizontal") * speed;
            animator.SetFloat("Speed", hMovement);
            if(Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(hMovement * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }

    void Respawn()
    {
        Debug.Log("Respawning");
        //TODO: Remove 1 life
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
