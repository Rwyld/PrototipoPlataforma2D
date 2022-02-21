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
        StartCoroutine("CD");

        if (distance < 10)
        {
            speed = 1f;
        }
    }

    public void Move()
    {
        transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);


        distance = Vector2.Distance(player.transform.position, transform.position);

      
    }



    IEnumerator CD()
    {
        yield return new WaitForSeconds(10);
        ResetPos();
    }

}
