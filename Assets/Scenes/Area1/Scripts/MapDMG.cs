using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDMG : RDamage
{
    private float distance;


    private void Start()
    {
        x = 1f;
        y = 0f;
    }

    private void Update()
    {
        Move();

       
    }

    public void Move()
    {
        //transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);


        distance = Vector2.Distance(player.transform.position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (distance < 10)
        {
            speed = 3f;
        }
        else
        {
            speed = 0f;
        }
    }

    
}
