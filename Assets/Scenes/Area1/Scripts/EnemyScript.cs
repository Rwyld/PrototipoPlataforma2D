using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject deathEffect;
    public MoveScript mv_player;
    public Collider2D bodyCol;
    [SerializeField] private Stats stats;
    public LayerMask groundLay;
    [SerializeField] private EnemyType Type;
    [SerializeField] private bool onMoving;
    [SerializeField] private float timeFlip = 5f;
    [SerializeField] private float timeReset = 5f;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawn;   
    [SerializeField] private Transform Target;
    [SerializeField] private Transform groundDetect;
    [SerializeField] private GameManager gameManager;
    public bool SetActive = true;
    public float timeShoot = 1f;
    public float timeShootReset = 1f;
    public enum EnemyType { EnemyMove, EnemyBow };
    
    public void TakeDamage(int damage)
    {
        stats.health -= damage;


        if (stats.health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mv_player.PlayerTakeDamage(stats.damageDeal);
        }
    }

    private void Die()
    {
        animator.SetFloat("Health", 0);
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Move()
    {
        rb.velocity = new Vector2(stats.speed * Time.deltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        stats.speed *= -1;
        
    }

    private void Timer()
    {
        timeFlip -= Time.deltaTime;
        if (timeFlip < 0f)
        {
            Flip();
            timeFlip = timeReset;
        }
    }

    private void Update()
    {

        switch (Type)
        {
            case EnemyType.EnemyMove:
                if (onMoving)
                {
                    animator.SetFloat("Speed", 1);
                    Move();
                    Timer();
                }
                else { animator.SetFloat("Speed", 0); }
                break;
            case EnemyType.EnemyBow:
                Attack();
                break;
        }
    
    }

    private void Attack()
    {
        var rangeAttack = Vector2.Distance(Target.position, transform.position);

        if (rangeAttack < 10)
        {          
            timeShoot -= Time.deltaTime;

            if (timeShoot < 0)
            {
                animator.SetFloat("PlayerDistance", rangeAttack);
                Instantiate(arrowPrefab, spawn.position, spawn.rotation);
                timeShoot = timeShootReset;
            }
            else animator.SetFloat("PlayerDistance", rangeAttack);
        }
    }

  

}
