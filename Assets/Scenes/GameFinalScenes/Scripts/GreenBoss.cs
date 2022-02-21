using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoss : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public MoveScript mv_player;
    public Collider2D bodyCol;
    [SerializeField] private Stats stats;
    [SerializeField] private EnemyType Type;
    [SerializeField] private bool onMoving;
    [SerializeField] private bool MeleeMob;
    [SerializeField] private float timeFlip = 5f;
    [SerializeField] private float timeReset = 5f;
    [SerializeField] private GameObject range_attack, range_attack1,  range_attack2;
    [SerializeField] private Transform spawn, spawn1, spawn1_1, spawn2, spawn2_1;
    [SerializeField] private Transform Target;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject TP_effect;
    public bool SetActive = true;
    public float timeShoot = 4f;
    public float timeShootReset = 5f;
    public LayerMask groundLay;
    public enum EnemyType { En_mover, En_static };
    public float rangeAttack;
    public float rangePlayer;
    public float MoveAttack;
    [SerializeField] private float speed;
    [SerializeField] private float TimeTPCD;
    [SerializeField] private float TimeTP;



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
                if (rangePlayer == 25)
                {
                    TimeTP -= Time.deltaTime;
                    if (TimeTP < 0)
                    {
                        StartCoroutine("BossAttack");
                        TimeTP = TimeTPCD;
                    }
                    

                }

                break;
        }



    }

    private void Attack()
    {
        rangeAttack = Vector2.Distance(Target.position, transform.position);

        if (rangeAttack < 35)
        {
            timeShoot -= Time.deltaTime;

            if (timeShoot < 0 && stats.health > 30 )
            {
                animator.SetTrigger("attack");
                Instantiate(range_attack, spawn.position, spawn.rotation);
                timeShoot = timeShootReset;
            }

            if (timeShoot < 0 && stats.health <= 30 && stats.health > 15 )
            {
                animator.SetTrigger("attack");
                Instantiate(range_attack1, spawn1.position, spawn.rotation);
                Instantiate(range_attack1, spawn1_1.position, spawn.rotation);
                Instantiate(range_attack, spawn.position, spawn.rotation);
                timeShoot = timeShootReset;
            }

            if (timeShoot < 0 && stats.health <= 15 && stats.health > 0)
            {
                animator.SetTrigger("attack");
                Instantiate(range_attack2, spawn2.position, spawn.rotation);
                Instantiate(range_attack2, spawn2_1.position, spawn.rotation);
                Instantiate(range_attack1, spawn1.position, spawn.rotation);
                Instantiate(range_attack, spawn.position, spawn.rotation);
                timeShoot = timeShootReset;
            }


        }

    }

    private void randomPos()
    {
        float x1 = Random.Range(-110, -50);
        float y1 = Random.Range(-150, -190);
        transform.position = new Vector2(x1, y1);
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

    IEnumerator BossAttack()
    {
        yield return new WaitForSeconds(3);
        Instantiate(TP_effect, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        randomPos();
        Rotation_mob ();
        Attack();
        
    }
}

