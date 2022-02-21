using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBossG : MonoBehaviour
{
    public int damage;
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool isMelee;
    public float time_off;
    public Animator effect;
    void Start()
    {

        if (!isMelee)
        {
            rb.velocity = transform.right * speed * Time.deltaTime;
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveScript player = collision.GetComponent<MoveScript>();

        var hit = collision.CompareTag("Ground");

        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }
        Destroy(gameObject, time_off);

        if (hit)
        {
            effect.SetBool("Touch", true);
        }
    }
}
