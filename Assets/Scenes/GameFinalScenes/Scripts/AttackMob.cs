using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMob : MonoBehaviour
{
    public int damage = 1;
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool isMelee;
    public float time_off;

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
        Player player = collision.GetComponent<Player>();


        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }
        Destroy(gameObject, time_off);

    }
}
