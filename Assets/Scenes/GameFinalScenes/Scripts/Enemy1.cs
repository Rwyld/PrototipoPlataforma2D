using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Player mv_player;
    public Collider2D bodyCol;
    [SerializeField] private Stats stats;
    [SerializeField] private EnemyType Type;
    [SerializeField] private bool onMoving;
    [SerializeField] private bool MeleeMob;
    [SerializeField] private float timeFlip = 5f;
    [SerializeField] private float timeReset = 5f;
    [SerializeField] private GameObject range_attack;
    [SerializeField] private Transform spawn;
    [SerializeField] private Transform Target;
    [SerializeField] private GameManager gameManager;
    public bool SetActive = true;
    public float timeShoot = 1f;
    public float timeShootReset = 1f;
    public LayerMask groundLay;
    public enum EnemyType { En_mover, En_static };
    public float rangeAttack;
    public float rangePlayer;
    public float MoveAttack;
    [SerializeField] private float speed;



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
        animator.SetInteger("Health", 0);
        Destroy(gameObject, 1.5f);
    }


    private void Rotation_mob()
    {
        var rotateMob = Target.position.x - transform.position.x;

        if (rotateMob > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rotateMob < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        animator.SetFloat("Speed", 1);

    }

    private void Timer()
    {
        timeFlip -= Time.deltaTime;
        if (timeFlip < 0f)
        {
            
            speed *= -1;
            timeFlip = timeReset;
        }
    }

    private void Update()
    {


        switch (Type)
        {
            case EnemyType.En_mover:
            
                if (onMoving)
                {
                    Move();
                    Timer();
                    Meele();
                }
                    

                break;
            case EnemyType.En_static:
                Attack();
                break;
        }



    }

    private void Attack()
    {
        rangeAttack = Vector2.Distance(Target.position, transform.position);

        if (rangeAttack < 35)
        {
            timeShoot -= Time.deltaTime;

            if (timeShoot < 0)
            {
                animator.SetFloat("PlayerDistance", rangeAttack);
                Instantiate(range_attack, spawn.position, spawn.rotation);
                timeShoot = timeShootReset;
            }
            else animator.SetFloat("PlayerDistance", rangeAttack);
        }

    }


    private void Meele()
    {
        rangePlayer = Vector2.Distance(Target.position, transform.position);
        Rotation_mob();

        if (rangePlayer < 20 && MeleeMob)
        {

            timeFlip = 30f;
            transform.position = Vector2.MoveTowards(transform.position, Target.position, MoveAttack * Time.deltaTime);

            timeShoot -= Time.deltaTime;

            if (rangePlayer <= 5 && timeShoot <= 0)
            {
                animator.SetTrigger("Attack");
                Instantiate(range_attack, spawn.position, spawn.rotation);
                timeShoot = timeShootReset;
            }
            
        }

    }

 
}
