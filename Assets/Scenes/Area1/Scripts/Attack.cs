using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    int damage = 2;

    /*private void OnCollisionEnter2D(Collider2D collision)
    {
        Enemy1 enemy = collision.GetComponent<Enemy1>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy1 enemy = collision.gameObject.GetComponent<Enemy1>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

}
