using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressPlatform : MonoBehaviour
{
    private void Start()
    {
        GameEvents.Ev.OnPressFloorButtton += Active;
    }

    private void Active()
    {
        transform.Translate(0f, 50f * Time.fixedDeltaTime, 0f);
        Debug.Log("Subiendo Plataforma");
    }
}
