using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameManager GM;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput; 
    private bool Grounded;
    public Transform ground;
    public float checkRadius;
    public LayerMask WhatIs;

    private float jumpConter;
    public float jumpTime;
    private bool jumping;
    public float health = 5f;

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GM.RestartGame();
            Debug.Log("Game Over");
            animator.SetInteger("Life", 0);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Update()
    {
        Grounded = Physics2D.OverlapCircle(ground.position, checkRadius, WhatIs );

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }



        if (Grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            animator.SetBool("Jumping", true);
            rb.velocity = Vector2.up * jumpForce;
            jumpConter = jumpTime;
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        if (Input.GetKey(KeyCode.Space) && jumping)
        {
            if (jumpConter > 0)
            { 
                rb.velocity = Vector2.up * jumpForce;
                jumpConter -= Time.deltaTime; 
            }
            else
            {
                jumping = false;
                animator.SetBool("Jumping", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
            animator.SetBool("Jumping", false);
        }

        GM.Pause();
    }



}
