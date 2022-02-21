using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    void Start()
    {
        GameEvents.Ev.PlatformDown += Fall;
    }

    private void Fall()
    {
        StartCoroutine("WaitForFall");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameEvents.Ev.FallDown();
    }

    IEnumerator WaitForFall()
    {
        Debug.Log("La Plataforma va a desaparecer en 3");
        yield return new WaitForSeconds(1);
        Debug.Log("La Plataforma va a desaparecer en 2");
        yield return new WaitForSeconds(1);
        Debug.Log("La Plataforma va a desaparecer en 1");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);


    }
}
