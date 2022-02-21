using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameManager GM;
    public Rigidbody2D rb;


    float MoveX = 0f;
    float MovSpeed = 100f;
    bool Jump = false;
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





    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * MovSpeed;
        animator.SetFloat("Speed", Mathf.Abs(MoveX));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("JumpTime");
        }
            
    }

    private void FixedUpdate()
    {
        controller.Move(MoveX * Time.fixedDeltaTime, false, Jump);
        
        
       
        
    }
    IEnumerator JumpTime()
    {
        Jump = true;
        animator.SetBool("Jumping", true);
        rb.mass = 1f;
        yield return new WaitForSeconds(1);
        rb.gravityScale = 10;
        yield return new WaitForSeconds(0.7f);
        rb.mass = 1;
        rb.gravityScale = 1;
        Jump = false;
        animator.SetBool("Jumping", false);

    }






}
