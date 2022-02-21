using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDmg : MonoBehaviour
{
    int damage = 1;
    float speedArrow = 10f;
    public Rigidbody2D rb; 
    

    void Start()
    {
        rb.velocity = transform.right * speedArrow;
        Destroy(gameObject, 2.5f);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        MoveScript player = collision.GetComponent<MoveScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
