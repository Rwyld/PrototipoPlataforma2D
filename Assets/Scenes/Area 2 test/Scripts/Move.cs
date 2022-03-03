using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private float flip = 5f;
    float delay = 5f;
    [SerializeField] private float x = -1f;
    [SerializeField] private float y = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(x * speed * Time.deltaTime, y * Time.deltaTime, 0);

        flip -= Time.deltaTime;
        if (flip < 0)
        {
            x *= -1;
            y *= -1;
            flip = delay;
        }
    }

    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveScript player = collision.GetComponent<MoveScript>();

        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }

    }

}
