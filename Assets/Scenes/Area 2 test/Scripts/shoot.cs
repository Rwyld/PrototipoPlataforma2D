using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float speed = 0.5f;
    public float speedRotation = 300f;
    private int damage = 1;


    private void Start()
    {
        Destroy(gameObject, 2.5f);
    }
    void Update()
    {
        ballMove();

    }


    public void ballMove()
    {
        transform.Translate(transform.position * speed * Time.deltaTime);
        transform.Rotate(0, 0, 300 * speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveScript player = collision.GetComponent<MoveScript>();

        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }




    }
}
