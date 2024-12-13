using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float move;

    public float speed;
    public float jump;

    bool grounded;

    private Animator anim; // Access the animator

    private bool isFacingRight;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal"); // Allows for horizontal movement

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move != 0)
        {
            anim.SetBool("isRunning", true); // Plays the running animation
        }
        else
        {
            anim.SetBool("isRunning", false); // Stops the animation 
        }
        if (!isFacingRight && move > 0)
        {
            Flip(); // Flips depedning on how the player is facing
        }
        else if (isFacingRight && move < 0)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10)); // Allows the player to jump
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            anim.SetBool("isJumping", true); // Plays the jump animation when jumping
        }
        else
        {
            anim.SetBool("isJumping", false); // Stops the jump animaion when not jumping
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }




    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    public void Flip()  // Flips depedning on how the player is facing
    {
        isFacingRight = !isFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }


}

