using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_position : MonoBehaviour
{
    public GameObject ball;
    public float time = 0.5f;
    public float delay = 0.5f;


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Instantiate(ball, transform.position, transform.rotation);
            time = delay;

        }

    }
}
