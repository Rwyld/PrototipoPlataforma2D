using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public GameObject AirPlatform;


    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.Translate(0f, -2f * Time.deltaTime, 0f);
        GameEvents.Ev.PlatformActive();
        AirPlatform.SetActive(false);
    }



}
